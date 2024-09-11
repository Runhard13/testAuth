namespace TestAuth.Core.Usecases.CreateUser.Models;

public record CreateUserRequest(string Username, string Password);

public record CreateUserModel(string Username, string PasswordSalt, string PasswordHash);
