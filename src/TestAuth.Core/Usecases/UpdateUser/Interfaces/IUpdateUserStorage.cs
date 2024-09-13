using TestAuth.Core.Services;
using TestAuth.Core.Usecases.UpdateUser.Models;

namespace TestAuth.Core.Usecases.UpdateUser.Interfaces;

public interface IUpdateUserStorage : IScopedService
{
    Task<UserModel?> GetUserById(Guid id);
    Task UpdateUser(UpdateUserRequest request);
}
