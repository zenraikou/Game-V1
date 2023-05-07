using Microsoft.AspNetCore.Identity;

namespace Game.Domain.Entities;

public class Role : IdentityRole<Guid>
{
    public new Guid Id { get; private init; } = Guid.NewGuid();
}
