using Microsoft.AspNetCore.Identity;
using User = Data.FoodMod.User;

namespace Service.TokenServices;

public interface ITokenService
{
    string CreateToken(User user, List<IdentityRole<long>> role);
}