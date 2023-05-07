namespace Game.Contracts.User;

public record UserRequest
{
    public Guid Id { get; private init; }
}
