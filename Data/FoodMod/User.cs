using Microsoft.AspNetCore.Identity;

namespace Data.FoodMod;

public class User: IdentityUser<long>  
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string MiddleName { get; set; }
    
    public DateTime BrithDate { get; set; }
    public string City { get; set; }
    public long PhoneNumber { get; set; }
    
    
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    
    
    
    
    
    // User -> Parameters
    public Parameters rParameters { get; set; }
    
    
    
    
    
    
    
    
    
    
    
}