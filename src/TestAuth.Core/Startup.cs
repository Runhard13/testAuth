using Microsoft.Extensions.DependencyInjection;
using TestAuth.Core.Usecases.CreateUser;
using TestAuth.Core.Usecases.GetCurrentUser;
using TestAuth.Core.Usecases.GetUsers;
using TestAuth.Core.Usecases.Login;
using TestAuth.Core.Usecases.UpdateUser;

namespace TestAuth.Core;

public static class Startup
{
    public static IServiceCollection RegisterCore(this IServiceCollection services)
    {
        services.AddScoped<LoginUsecase>();
        services.AddScoped<CreateUserUsecase>();
        services.AddScoped<GetCurrentUserUsecase>();
        services.AddScoped<GetUsersUsecase>();
        services.AddScoped<UpdateUserUsecase>();
        return services;
    }
}
