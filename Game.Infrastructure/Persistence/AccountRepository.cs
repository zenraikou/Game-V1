using Microsoft.AspNetCore.Identity;

namespace Game.Infrastructure.Persistence;

public class AccountRepository
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
}
