namespace Game.Contracts.Item;

public class ItemResponse
{
    public Guid Id { get; private init; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}
