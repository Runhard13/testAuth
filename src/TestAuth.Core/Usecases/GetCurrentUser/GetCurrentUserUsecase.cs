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

        return user == null
            ? Result<GetCurrentUserResponse>.Invalid().WithMessage("Пользователь не найден")
            : Result<GetCurrentUserResponse>.Success(user);
    }
}
