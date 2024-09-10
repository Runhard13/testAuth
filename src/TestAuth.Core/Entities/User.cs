namespace TestAuth.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordSalt { get; set; }
    public required string PasswordHash { get; set; }
    public required bool IsActive { get; set; }
}
