namespace Game.Contracts.Users;

public record UserRequest
{
    public Guid Id { get; private init; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
}
