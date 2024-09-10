using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TestAuth.Core.Constants;
using TestAuth.Core.Services;
using TestAuth.Core.Usecases.Login.Interfaces;
using TestAuth.Core.Usecases.Login.Models;

namespace TestAuth.Infrastructure.Authentication.Jwt;

public class JwtTokenService(IAppSettings settings) : IJwtTokenService
{

    public ValidateTokenResponse ValidateAccessToken(string accessToken, bool isValidateWithExpiry = true)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(settings.AuthSettings.ApiSecret);
        try
        {
            tokenHandler.ValidateToken(accessToken, new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = isValidateWithExpiry,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == TokenClaimKeys.UserId).Value);

            bool isGenerationSuccessful = userId != Guid.Empty;

            return new(isGenerationSuccessful, userId);
        }
        catch
        {
            return new(false, Guid.Empty);
        }
    }

    public string GenerateAcceesToken(GenerateTokenRequest request)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(settings.AuthSettings.ApiSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new(new[]
            {
                new Claim(TokenClaimKeys.UserId, request.UserId.ToString()),
            }),
            Expires = DateTime.UtcNow.AddMinutes(int.Parse(settings.AuthSettings.TokenLifetimeMinutes)),
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
