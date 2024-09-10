using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestAuth.Infrastructure.DAL;

internal static class Startup
{
    internal static IServiceCollection RegisterDal(this IServiceCollection services, IConfiguration config, IWebHostEnvironment environment)
    {
        return services;
    }

}

