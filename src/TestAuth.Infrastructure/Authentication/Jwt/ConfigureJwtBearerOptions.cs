using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TestAuth.Core.Services;
using TestAuth.Core.Utils.ActionResult;
using TestAuth.Core.Utils.ActionResult.Extensions;

namespace TestAuth.Infrastructure.Authentication.Jwt;

public class ConfigureJwtBearerOptions(IAppSettings settings) : IConfigureNamedOptions<JwtBearerOptions>
{
    public void Configure(JwtBearerOptions options)
    {
        Configure(string.Empty, options);
    }

    public void Configure(string? name, JwtBearerOptions options)
    {
        if (name != JwtBearerDefaults.AuthenticationScheme)
            return;

        byte[] key = Encoding.ASCII.GetBytes(settings.AuthSettings.ApiSecret);

        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateLifetime = true,
            ValidateAudience = false,
            RoleClaimType = ClaimTypes.Role,
            ClockSkew = TimeSpan.Zero
        };
        options.Events = new()
        {
            OnChallenge = async context =>
            {
                context.HandleResponse();
                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsJsonAsync(
                        Result.Unauthorized().WithMessage("You must be authenticated to do that").PackAsApiResponse()
                    );
                }
            },
            OnForbidden = async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsJsonAsync(
                    Result.PermissionDenied().WithMessage("Please make sure you have the correct access rights").PackAsApiResponse()
                );
            },
            OnMessageReceived = context =>
            {
               string? accessToken = context.Request.Headers.Authorization
                    .FirstOrDefault()?
                    .Split(" ")[^1];

                context.Token = accessToken;
                return Task.CompletedTask;
            },
        };
    }
}
