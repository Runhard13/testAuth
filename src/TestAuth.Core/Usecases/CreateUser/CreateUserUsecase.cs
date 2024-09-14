using TestAuth.Core.Services;
using TestAuth.Core.Usecases.CreateUser.Interfaces;
using TestAuth.Core.Usecases.CreateUser.Models;
using TestAuth.Core.Utils.ActionResult;

namespace TestAuth.Core.Usecases.CreateUser;

public class CreateUserUsecase(ICreateUserStorage storage, IPasswordService passwordService)
{
    public async Task<Result> CreateUsers(IEnumerable<CreateUserRequest> request)
    {
        var users = from r in request
            let pwdData = passwordService.GeneratePasswordData(r.Password)
            select new CreateUserModel(r.Username, pwdData.passwordSalt, pwdData.passwordHash);

        await storage.CreateUsers(users);
        return Result.Success();
    }

    public async Task<Result<int>> CountUsers()
    {
        return Result<int>.Success(await storage.CountUsers());
    }
}
