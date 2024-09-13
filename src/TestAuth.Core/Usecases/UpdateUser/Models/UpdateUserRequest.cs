namespace TestAuth.Core.Usecases.UpdateUser.Models;

public record UpdateUserRequest(Guid UserId, bool IsActive);
