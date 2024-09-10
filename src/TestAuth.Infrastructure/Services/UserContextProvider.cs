using Microsoft.AspNetCore.Http;
using TestAuth.Core.Constants;
using TestAuth.Core.Services;

namespace TestAuth.Infrastructure.Services;

public class UserContextProvider(IHttpContextAccessor httpContextAccessor) : IUserContextProvider
{
    public UserContextModel GetUserContext()
    {
        var context = httpContextAccessor.HttpContext;
        if (context == null)
            return new(Guid.Empty);

        var user = context.User;
        try
        {
            var userId = Guid.Parse(user.Claims.First(x => x.Type == TokenClaimKeys.UserId).Value);
            return new(userId);
        }
        catch
        {
            return new(Guid.Empty);
        }
    }

}
