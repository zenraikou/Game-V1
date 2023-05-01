using Mapster;

namespace Game.Core.Contracts.Item;

public class GetItemResponse
{
    [AdaptIgnore(MemberSide.Source)]
    public Guid Id { get; private init; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Description { get; set; }
}
