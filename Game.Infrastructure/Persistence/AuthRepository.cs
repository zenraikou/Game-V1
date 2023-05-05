using Game.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Game.Infrastructure.Persistence;

public class AuthRepository
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
}
