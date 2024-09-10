using TestAuth.Core.Models;

namespace TestAuth.Core.Utils.ActionResult.Extensions;

public static class ResultExtensions
{
    public static ApiResponseModel PackAsApiResponse(this Result result)
    {
        return new()
        {
            Errors = new()
            {
                Message = result.Message ?? string.Empty,
                Descriptions = result.Errors ?? []
            }
        };
    }

    public static BaseApiResponseModel<T> PackAsApiResponse<T>(this Result<T> result)
    {
        return new()
        {
            Data = result.Value,
            Errors = new()
            {
                Message = result.Message ?? string.Empty,
                Descriptions = result.Errors ?? []
            }
        };
    }

    public static PaginatedApiResponseModel<T> PackAsPaginatedApiResponse<T>(this Result<T> result)
    {
        return new()
        {
            Data = result.Value,
            Errors = new()
            {
                Message = result.Message ?? string.Empty,
                Descriptions = result.Errors ?? []
            },
            Cursor = result.Cursor ?? 0
        };
    }
}
