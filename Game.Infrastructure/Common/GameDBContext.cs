using Game.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Game.Infrastructure.Common;

public class GameDBContext : IdentityDbContext<User>
{
    public GameDBContext(DbContextOptions<GameDBContext> options) : base(options) { }

    public DbSet<Item> Items => Set<Item>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
        modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
        modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
        
        modelBuilder.Entity<Item>().HasData(
            new Item
            {
                Name = "Dagon",
                Description = "A dagger crafted from the tooth of a Pure Silver Dragon."
            },
            new Item
            {
                Name = "Yasha",
                Description = "A sword crafted from the talon of a Pure Silver Dragon."
            },
            new Item
            {
                Name = "Buriza",
                Description = "A bow crafted from the wing of a Pure Silver Dragon."
            },
            new Item
            {
                Name = "Vanguard",
                Description = "A shield crafted from the scales of a Pure Silver Dragon."
            });
    }
}
