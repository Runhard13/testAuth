using TestAuth.Core.Services;
using TestAuth.Core.Usecases.GetCurrentUser.Interfaces;
using TestAuth.Core.Usecases.GetCurrentUser.Models;
using TestAuth.Core.Utils.ActionResult;

namespace TestAuth.Core.Usecases.GetCurrentUser;

public class GetCurrentUserUsecase(IGetCurrentUserStorage storage, IUserContextProvider userProvider)
{
    public async Task<Result<GetCurrentUserResponse>> GetCurrentUserInfo()
    {
        var userContext = userProvider.GetUserContext();
        var user = await storage.GetUserById(userContext.Id);

        if (user == null)
            return Result<GetCurrentUserResponse>.Invalid().WithMessage("User not found");

        return user.IsActive
            ? Result<GetCurrentUserResponse>.Success(user)
            : Result<GetCurrentUserResponse>.Invalid().WithMessage("User not active");
    }
}
