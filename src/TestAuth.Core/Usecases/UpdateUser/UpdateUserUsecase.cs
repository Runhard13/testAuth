using TestAuth.Core.Usecases.UpdateUser.Interfaces;
using TestAuth.Core.Usecases.UpdateUser.Models;
using TestAuth.Core.Utils.ActionResult;

namespace TestAuth.Core.Usecases.UpdateUser;

public class UpdateUserUsecase(IUpdateUserStorage storage)
{
    public async Task<Result> UpdateUser(UpdateUserRequest request)
    {
        var user = await storage.GetUserById(request.UserId);
        if (user == null)
            return Result.Invalid().WithMessage("Пользователь не найден");

        await storage.UpdateUser(request);
        return Result.Success();
    }
}
