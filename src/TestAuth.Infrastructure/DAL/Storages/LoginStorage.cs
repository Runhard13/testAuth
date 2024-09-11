using TestAuth.Core.Usecases.Login.Interfaces;
using TestAuth.Core.Usecases.Login.Models;

namespace TestAuth.Infrastructure.DAL.Storages;

public class LoginStorage : ILoginStorage
{
    public Task<UserModel?> GetUserByUsername(string username) => throw new NotImplementedException();
}
