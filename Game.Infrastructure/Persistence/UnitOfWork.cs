using Game.Core.Common.Interfaces.Persistence;
using Game.Domain.Entities;
using Game.Infrastructure.Common.Data;
using Microsoft.AspNetCore.Identity;

namespace Game.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfwork
{
    private readonly GameDBContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public IAccountRepository Accounts { get; private set; }
    public IItemRepository Items { get; private set; }

    public UnitOfWork(
        GameDBContext context,
        UserManager<User> userManager,
        RoleManager<Role> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        
        Accounts = new AccountRepository(context, userManager, roleManager);
        Items = new ItemRepository(context);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
