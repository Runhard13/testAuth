using FluentMigrator.Runner;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestAuth.Core.Exceptions;
using TestAuth.Infrastructure.DAL.Migrations;

namespace TestAuth.Infrastructure.DAL;

internal static class Startup
{
    internal static IServiceCollection RegisterDal(this IServiceCollection services, IConfiguration config, IWebHostEnvironment environment)
    {
        string connectionString = config.GetConnectionString("DBConnectionString") ?? throw new InternalServerException("Не задана строка подключения к БД");

        var provider = services
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddPostgres()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(CreateUsers).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);

        var scope = provider.CreateScope();
        var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();

        return services;
    }

}
