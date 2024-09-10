using TestAuth.Core.Services;
using TestAuth.Core.Usecases.GetCurrentUser.Models;

namespace TestAuth.Core.Usecases.GetCurrentUser.Interfaces;

public interface IGetCurrentUserStorage : IScopedService
{
    Task<GetCurrentUserResponse?> GetUserById(Guid id);
}
