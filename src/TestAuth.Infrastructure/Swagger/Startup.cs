using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TestAuth.Infrastructure.Swagger;

internal static class Startup
{
    internal const string ApplicationTitle = "Test Auth Api";

    internal static IServiceCollection AddSwaggerBuilder(this IServiceCollection services)
    {

        services.AddFluentValidationRulesToSwagger();

        services.AddSwaggerGen(setup =>
        {
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
