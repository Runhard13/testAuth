using TestAuth.Core.Usecases.Login.Models;

namespace TestAuth.Core.Usecases.Login.Interfaces;

public interface ILoginStorage
{
    Task<UserModel?> GetUserByUsername(string username);
}
