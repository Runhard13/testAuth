using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TestAuth.Core.Exceptions;
using TestAuth.Infrastructure.Cors;

namespace TestAuth.Infrastructure.Validation;

internal static class Startup
{
    public static IServiceCollection AddValidationBuilder(this IServiceCollection services)
    {
        ValidatorOptions.Global.LanguageManager.Culture = new("ru");

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblies
        (
            [
                typeof(InternalServerException).Assembly,
                typeof(CorsSettings).Assembly,
            ]
        );
        return services;
    }
}
