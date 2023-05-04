namespace Game.Domain.Entities;

public record User
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public DateTime Timestamp { get; private init; } = DateTime.UtcNow;
}
