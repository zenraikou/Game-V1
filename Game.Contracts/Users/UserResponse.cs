namespace Game.Contracts.Users;

public record UserResponse
{
    public Guid Id { get; private init; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
}
