using Game.Core.Common.Interfaces.Persistence;
using Game.Domain.Entities;
using Game.Infrastructure.Common;
using Microsoft.AspNetCore.Identity;

namespace Game.Infrastructure.Persistence;

public class AccountRepository : IAccountRepository
{
    private readonly GameDBContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountRepository(
        GameDBContext context,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public Task<User> Login(User user)
    {
        throw new NotImplementedException();
    }

    public async Task Register(User user)
    {
        await _userManager.CreateAsync(user, user.PasswordHash!);
    }
}
