using Microsoft.AspNetCore.Mvc;
using TestAuth.Core.Exceptions;
using TestAuth.Core.Utils.ActionResult;
using TestAuth.Core.Utils.ActionResult.Enum;
using TestAuth.Core.Utils.ActionResult.Extensions;

namespace TestAuth.Api.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected IActionResult FromResult(Result result)
    {
        return result.Type switch
        {
            ResultType.Success => Ok(),
            ResultType.Unauthorized => Unauthorized(result.PackAsApiResponse()),
            ResultType.PermissionDenied => StatusCode(StatusCodes.Status403Forbidden, result.PackAsApiResponse()),
            ResultType.NotFound => BadRequest(result.PackAsApiResponse()),
            ResultType.Invalid => BadRequest(result.PackAsApiResponse()),
            _ => throw new InternalServerException(
                $"{Enum.GetName(typeof(ResultType), result.Type)} result type not implemented for transform to api response"
            )
        };
    }

    protected IActionResult FromResult<T>(Result<T> result)
    {
        if (result.IsPaginated)
        {
            return result.Type switch
            {
                ResultType.Success => Ok(result.PackAsPaginatedApiResponse()),
                ResultType.Unauthorized => Unauthorized(result.PackAsPaginatedApiResponse()),
                ResultType.PermissionDenied => StatusCode(StatusCodes.Status403Forbidden, result.PackAsPaginatedApiResponse()),
                ResultType.NotFound => BadRequest(result.PackAsPaginatedApiResponse()),
                ResultType.Invalid => BadRequest(result.PackAsPaginatedApiResponse()),
                _ => throw new InternalServerException(
                    $"{Enum.GetName(typeof(ResultType), result.Type)} result type not implemented for transform to api response"
                )
            };
        }
        return result.Type switch
        {
            ResultType.Success => Ok(result.PackAsApiResponse()),
            ResultType.Unauthorized => Unauthorized(result.PackAsApiResponse()),
            ResultType.PermissionDenied => StatusCode(StatusCodes.Status403Forbidden, result.PackAsApiResponse()),
            ResultType.NotFound => BadRequest(result.PackAsApiResponse()),
            ResultType.Invalid => BadRequest(result.PackAsApiResponse()),
            _ => throw new InternalServerException(
                $"{Enum.GetName(typeof(ResultType), result.Type)} result type not implemented for transform to api response"
            )
        };
    }
}
