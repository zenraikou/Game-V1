using Microsoft.AspNetCore.Identity;

namespace Game.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public new Guid Id { get; private init; } = Guid.NewGuid();
    public DateTime Timestamp { get; private init; } = DateTime.UtcNow;
}
