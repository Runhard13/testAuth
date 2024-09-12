using TestAuth.Core.Usecases.CreateUser;
using TestAuth.Core.Usecases.CreateUser.Models;

namespace TestAuth.Infrastructure.DAL.InitializeDb;

public class DbInitializer(CreateUserUsecase userCreator)
{
    public async Task CreateDefaultUsers()
    {
        var userCount = await userCreator.CountUsers();

        if (userCount.Value == 0)
        {
            await userCreator.CreateUsers(DefaultUsers.UsersForSeed);
        }
    }
}

public static class DefaultUsers
{
    public static IEnumerable<CreateUserRequest> UsersForSeed { get; } =
    [
        new CreateUserRequest("john", "password"),
        new CreateUserRequest("arthur", "password"),
        new CreateUserRequest("hosea", "password"),
        new CreateUserRequest("dutch", "password"),
        new CreateUserRequest("strauss", "password"),
        new CreateUserRequest("swanson", "password"),
        new CreateUserRequest("uncle", "password"),
        new CreateUserRequest("trelawny", "password"),
        new CreateUserRequest("williamson", "password"),
        new CreateUserRequest("javier", "password"),
        new CreateUserRequest("lenny", "password"),
        new CreateUserRequest("micah", "password"),
        new CreateUserRequest("sadie", "password"),
        new CreateUserRequest("pearson", "password"),
        new CreateUserRequest("grimshaw", "password")
    ];

}
