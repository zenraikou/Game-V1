namespace Game.Contracts.Items;

public class ItemRequest
{
    public Guid Id { get; private init; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}
