using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestAuth.Api.Controllers.Base;
using TestAuth.Core.Models;
using TestAuth.Core.Usecases.Login;
using TestAuth.Core.Usecases.Login.Models;

namespace TestAuth.Api.Controllers;

public class AuthController : BaseController
{
    /// <summary>
    /// Получить токен для доступа к апи
    /// </summary>
    /// <response code="200">Аутентификация прошла успешно</response>
    /// <returns></returns>
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(BaseApiResponseModel<LoginResponse>), 200)]
    public async Task<IActionResult> Login([FromServices] LoginUsecase useCase, [FromBody] LoginRequest request)
    {
        var result = await useCase.Login(request);
        return FromResult(result);
    }

}
