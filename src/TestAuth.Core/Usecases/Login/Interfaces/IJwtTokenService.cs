using TestAuth.Core.Services;
using TestAuth.Core.Usecases.Login.Models;

namespace TestAuth.Core.Usecases.Login.Interfaces;

public interface IJwtTokenService : IScopedService
{
    ValidateTokenResponse ValidateAccessToken(string accessToken, bool isValidateWithExpiry = true);
    string GenerateAcceesToken(GenerateTokenRequest request);
}
