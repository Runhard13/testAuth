namespace TestAuth.Infrastructure.DAL.Entities;

public class User
{
    public Guid Id { get; init; }
    public required string Username { get; init; }
    public required string PasswordSalt { get; init; }
    public required string PasswordHash { get; init; }
    public required bool IsActive { get; init; }
}
