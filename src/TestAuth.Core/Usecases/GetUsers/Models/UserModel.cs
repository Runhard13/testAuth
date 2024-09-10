namespace TestAuth.Core.Usecases.GetUsers.Models;

public record UserModel(Guid Id, string Username, bool IsActive);
