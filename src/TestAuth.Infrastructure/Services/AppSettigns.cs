using Microsoft.Extensions.Configuration;
using TestAuth.Core.Exceptions;
using TestAuth.Core.Services;

namespace TestAuth.Infrastructure.Services;

public class AppSettigns(IConfiguration configuration) : IAppSettings
{

    public string ConnectionString { get; init; } = configuration.GetConnectionString("DBConnectionString") ?? throw new InternalServerException("Не указана строка подключения к базе данных");
    public AuthSettings AuthSettings { get; init; } = configuration.GetSection("Authentication").Get<AuthSettings>() ?? throw new InternalServerException("Не заданы настройки аутентификации");
}
