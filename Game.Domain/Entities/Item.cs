namespace Game.Domain.Entities;

public record Item
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime Timestamp { get; private init; } = DateTime.UtcNow;
}
