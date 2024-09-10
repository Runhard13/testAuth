using Microsoft.Extensions.DependencyInjection;
using TestAuth.Core.Usecases.Login;

namespace TestAuth.Core;

public static class Startup
{
    public static IServiceCollection RegisterCore(this IServiceCollection services)
    {
        services.AddScoped<LoginUsecase>();
        return services;
    }
}
