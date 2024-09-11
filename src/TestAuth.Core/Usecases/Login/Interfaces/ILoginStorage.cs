using TestAuth.Core.Services;
using TestAuth.Core.Usecases.Login.Models;

namespace TestAuth.Core.Usecases.Login.Interfaces;

public interface ILoginStorage : IScopedService
{
    Task<UserModel?> GetUserByUsername(string username);
}
