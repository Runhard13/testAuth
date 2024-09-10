namespace TestAuth.Core.Usecases.GetCurrentUser.Models;

public record GetCurrentUserResponse(Guid Id, string Username, bool IsActive);
