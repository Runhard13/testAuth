using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestAuth.Api.Controllers.Base;
using TestAuth.Core.Models;
using TestAuth.Core.Usecases.GetCurrentUser;
using TestAuth.Core.Usecases.GetCurrentUser.Models;
using TestAuth.Core.Usecases.GetUsers;
using UserModel = TestAuth.Core.Usecases.GetUsers.Models.UserModel;

namespace TestAuth.Api.Controllers;

public class UserController : BaseController
{
    /// <summary>
    /// Получить информацию о текущем пользователе
    /// </summary>
    /// <param name="useCase"></param>
    /// <returns></returns>
    [HttpGet("current")]
    [ProducesResponseType(typeof(BaseApiResponseModel<GetCurrentUserResponse>), 200)]
    public async Task<IActionResult> GetCurrentUser([FromServices] GetCurrentUserUsecase useCase)
    {
        var result = await useCase.GetCurrentUserInfo();
        return FromResult(result);
    }

    /// <summary>
    /// Получить список пользователей
    /// </summary>
    /// <param name="useCase"></param>
    /// <returns></returns>
    [HttpPost("users")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(BaseApiResponseModel<List<UserModel>>), 200)]
    public async Task<IActionResult> Login([FromServices] GetUsersUsecase useCase)
    {
        var result = await useCase.GetUsers();
        return FromResult(result);
    }
}
