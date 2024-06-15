using System.IdentityModel.Tokens.Jwt;
using Data.Extensions;
using Data.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.TokenServices;
using User = Data.FoodMod.User;

namespace WebApplication1.Controllers.FoodMod;

[ApiController]
[Route("accounts")]
public class AccountsController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<long>> _roleManager;
    private readonly ApplicationContext _context;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _configuration;

    public AccountsController(ITokenService tokenService, ApplicationContext context, UserManager<User> userManager,RoleManager<IdentityRole<long>> roleManager,  IConfiguration configuration)
    {
        _tokenService = tokenService;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }
    
    [HttpPost("AddRole")]
    public async Task<IActionResult> Create(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole<long>(name));
            if (!result.Succeeded) return BadRequest(ModelState);
            
        }
        return Ok(name);
    }
    
    [HttpDelete("DeleteRole")]
    public async Task<IActionResult> Delete(string Name)
    {
        IdentityRole<long> role = await _roleManager.FindByNameAsync(Name);
        if (role != null)
        {
            IdentityResult result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded) return BadRequest(ModelState);
        }

        return Ok("Role Has been deleted");
    }
    
    [HttpPost("AddRoleToUser")]
    public async Task<IActionResult> AddRole(string Name, string roles)
    {   User user = await _userManager.FindByNameAsync(Name);
        IdentityRole<long> role = await _roleManager.FindByNameAsync(roles);
        
        if (user != null && role != null)
        {
            var result =  await _userManager.AddToRoleAsync(user, roles);
            if (!result.Succeeded) return BadRequest(ModelState);
        }

        return Ok("Role has been claimed");
    }
    
    
    [HttpPost("DeleteRoleToUser")]
    public async Task<IActionResult> DeleteRole(string Name, string roles)
    {   User user = await _userManager.FindByNameAsync(Name);
        IdentityRole<long> role = await _roleManager.FindByNameAsync(roles);
        
        if (user != null && role != null)
        {
            var result =  await _userManager.RemoveFromRoleAsync(user, roles);
            if (!result.Succeeded) return BadRequest(ModelState);
        }

        return Ok("Role has been taken");
    }

    
    
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var managedUser = await _userManager.FindByEmailAsync(request.Email);
        
        if (managedUser == null)
        {
            return BadRequest("Bad credentials");
        }
        
        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);
        
        if (!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }
        
        var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);
        
        if (user is null)
            return Unauthorized();

        var roleIds = await _context.UserRoles.Where(r => r.UserId == user.Id).Select(x => x.RoleId).ToListAsync();
        var roles = _context.Roles.Where(x => roleIds.Contains(x.Id)).ToList();
        
        var accessToken = _tokenService.CreateToken(user, roles);
        user.RefreshToken = _configuration.GenerateRefreshToken();
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_configuration.GetSection("Jwt:RefreshTokenValidityInDays").Get<int>());

        await _context.SaveChangesAsync();
        
        return Ok(new AuthResponse
        {
            Username = user.UserName!,
            Email = user.Email!,
            Token = accessToken,
            RefreshToken = user.RefreshToken
        });
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(request);
        
        var user = new User
        { 
            FirstName = request.FirstName, 
            LastName = request.LastName,
            MiddleName = request.MiddleName,
            Email = request.Email, 
            UserName = request.Email,
            BrithDate = request.BirthDate,
            City = request.City,
            PhoneNumber = request.PhoneNumber
        };
        
        var result = await _userManager.CreateAsync(user, request.Password);
        
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

         if (!result.Succeeded) return BadRequest(ModelState);
        
        var findUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

        if (findUser == null) throw new Exception($"User {request.Email} not found");

        //await _userManager.AddToRoleAsync(findUser, "Member");
            
        return await Authenticate(new AuthRequest
        {
            Email = request.Email,
            Password = request.Password
        });
    }
    
    [HttpPost]
    [Route("refresh-token")]
    public async Task<IActionResult> RefreshToken(TokenModel? tokenModel)
    {
        if (tokenModel is null)
        {
            return BadRequest("Invalid client request");
        }

        var accessToken = tokenModel.AccessToken;
        var refreshToken = tokenModel.RefreshToken;
        var principal = _configuration.GetPrincipalFromExpiredToken(accessToken);
        
        if (principal == null)
        {
            return BadRequest("Invalid access token or refresh token");
        }
        
        var username = principal.Identity!.Name;
        var user = await _userManager.FindByNameAsync(username!);

        if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return BadRequest("Invalid access token or refresh token");
        }

        var newAccessToken = _configuration.CreateToken(principal.Claims.ToList());
        var newRefreshToken = _configuration.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        await _userManager.UpdateAsync(user);

        return new ObjectResult(new
        {
            accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
            refreshToken = newRefreshToken
        });
    }
    
    [Authorize]
    [HttpPost]
    [Route("revoke/{username}")]
    public async Task<IActionResult> Revoke(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null) return BadRequest("Invalid user name");

        user.RefreshToken = null;
        await _userManager.UpdateAsync(user);

        return Ok();
    }
    
    [Authorize]
    [HttpPost]
    [Route("revoke-all")]
    public async Task<IActionResult> RevokeAll()
    {
        var users = _userManager.Users.ToList();
        foreach (var user in users)
        {
            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
        }

        return Ok();
    }
}


