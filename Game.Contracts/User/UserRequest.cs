namespace Game.Contracts.User;

public record UserRequest
{
    public Guid Id { get; private init; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
}
