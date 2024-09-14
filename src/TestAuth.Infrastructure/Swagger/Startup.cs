using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TestAuth.Infrastructure.Swagger;

internal static class Startup
{
    internal const string ApplicationTitle = "Test Auth Api";

    internal static IServiceCollection AddSwaggerBuilder(this IServiceCollection services)
    {

        services.AddFluentValidationRulesToSwagger();

        services.AddSwaggerGen(setup =>
        {
            setup.AddSecurityDefinition("Bearer", new()
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Cookie,
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            setup.AddSecurityRequirement(new()
            {
                {
                    new()
                    {
                        Reference = new()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });


            setup.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "TestAuth.Api.xml"));
        });

        return services;
    }

    internal static IApplicationBuilder UseSwaggerBuilder(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
