using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestAuth.Core.Services;
using TestAuth.Infrastructure.Authentication;
using TestAuth.Infrastructure.Cors;
using TestAuth.Infrastructure.DAL;
using TestAuth.Infrastructure.DAL.InitializeDb;
using TestAuth.Infrastructure.Services;
using TestAuth.Infrastructure.Swagger;
using TestAuth.Infrastructure.Validation;

namespace TestAuth.Infrastructure;

public static class Startup
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration config, IWebHostEnvironment environment)
    {
        services.RegisterDal(config, environment);
        services.AddAuth(config);

        services.AddSingleton<IAppSettings, AppSettigns>();
        services.AddScoped<DbInitializer>();

        services.AddSwaggerBuilder();
        services.AddValidationBuilder();

        services.AddCorsPolicy(config);

        services.AddHttpContextAccessor();
        services.AddScoped<IUserContextProvider, UserContextProvider>();
        services.AddServices();

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseCorsPolicy();
        app.UseAuth();
        app.UseSwaggerBuilder();

        return app;
    }

    public static async Task InitializeDatabase(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var defaultInitializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
        await defaultInitializer.CreateDefaultUsers();
    }


    private static IServiceCollection AddServices(this IServiceCollection services) =>
        services
            .AddServicesByInterface(typeof(ITransientService), ServiceLifetime.Transient)
            .AddServicesByInterface(typeof(IScopedService), ServiceLifetime.Scoped);

    private static IServiceCollection AddServicesByInterface(this IServiceCollection services, Type interfaceType, ServiceLifetime lifetime)
    {
        var interfaceTypes =
            AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(x => x.FullName == null || !x.FullName.StartsWith("StoreWeb.Tests"))
                .SelectMany(s => s.GetTypes())
                .Where(t => interfaceType.IsAssignableFrom(t)
                    && t is { IsClass: true, IsAbstract: false })
                .Select(t => new
                {
                    Service = t.GetInterfaces().FirstOrDefault(),
                    Implementation = t
                })
                .Where(t => t.Service is not null
                    && interfaceType.IsAssignableFrom(t.Service));

        foreach (var type in interfaceTypes)
        {
            services.AddServiceByInterface(type.Service!, type.Implementation, lifetime);
        }

        return services;
    }

    private static IServiceCollection AddServiceByInterface(this IServiceCollection services, Type serviceType, Type implementationType, ServiceLifetime lifetime) =>
        lifetime switch
        {
            ServiceLifetime.Transient => services.AddTransient(serviceType, implementationType),
            ServiceLifetime.Scoped => services.AddScoped(serviceType, implementationType),
            ServiceLifetime.Singleton => services.AddSingleton(serviceType, implementationType),
            _ => throw new ArgumentException("Invalid lifeTime", nameof(lifetime))
        };
}
