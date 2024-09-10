using TestAuth.Core.Usecases.GetUsers.Interfaces;
using TestAuth.Core.Usecases.GetUsers.Models;
using TestAuth.Core.Utils.ActionResult;

namespace TestAuth.Core.Usecases.GetUsers;

public class GetUsersUsecase(IGetUsersStorage storage)
{
    public async Task<Result<List<UserModel>>> GetUsers()
    {
        var users = await storage.GetUsers();
        return Result<List<Models.UserModel>>.Success(users);
    }
}
