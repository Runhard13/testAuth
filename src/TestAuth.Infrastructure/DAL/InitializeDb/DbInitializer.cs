using TestAuth.Core.Services;
using TestAuth.Core.Usecases.CreateUser;

namespace TestAuth.Infrastructure.DAL.InitializeDb;

public class DbInitializer(CreateUserUsecase userCreator)
{
    public async Task CreateDefaultUsers()
    {
        var userCount = await userCreator.CountUsers();

        if (userCount == 0)
        {
            await userCreator.CreateUsers()
        }
    }
}


