using Game.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Game.Infrastructure.Common.Data;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
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
