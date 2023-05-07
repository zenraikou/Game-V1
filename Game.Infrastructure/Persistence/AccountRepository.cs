using Game.Core.Common.Interfaces.Persistence;
using Game.Domain.Entities;
using Game.Infrastructure.Common.Data;
using Microsoft.AspNetCore.Identity;

namespace Game.Infrastructure.Persistence;

public class AccountRepository : IAccountRepository
{
    private readonly GameDBContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public AccountRepository(
        GameDBContext context,
        UserManager<User> userManager,
        RoleManager<Role> roleManager)
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
