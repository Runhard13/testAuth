using TestAuth.Core.Services;
using TestAuth.Core.Usecases.GetUsers.Models;

namespace TestAuth.Core.Usecases.GetUsers.Interfaces;

public interface IGetUsersStorage : IScopedService
{
    Task<List<UserModel>> GetUsers();
}
