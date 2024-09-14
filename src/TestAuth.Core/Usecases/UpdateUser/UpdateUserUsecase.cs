using TestAuth.Core.Usecases.UpdateUser.Interfaces;
using TestAuth.Core.Usecases.UpdateUser.Models;
using TestAuth.Core.Utils.ActionResult;

namespace TestAuth.Core.Usecases.UpdateUser;

public class UpdateUserUsecase(IUpdateUserStorage storage)
{
    public async Task<Result<UpdateUserResponse>> UpdateUser(UpdateUserRequest request)
    {
        var user = await storage.GetUserById(request.UserId);
        if (user == null)
            return Result<UpdateUserResponse>.Invalid().WithMessage("User not found");

        var updatedUser = await storage.UpdateUser(request);
        return Result<UpdateUserResponse>.Success(updatedUser);
    }
}
