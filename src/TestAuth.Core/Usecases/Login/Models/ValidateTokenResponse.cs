namespace TestAuth.Core.Usecases.Login.Models;

public record ValidateTokenResponse(bool IsSuccess, Guid UserId);
