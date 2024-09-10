namespace TestAuth.Core.Usecases.Login.Models;

public record UserModel(Guid UserId, string PasswordSalt, string PasswordHash, bool IsActive);
