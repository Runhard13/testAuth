using TestAuth.Core.Services;
using TestAuth.Core.Usecases.CreateUser.Models;

namespace TestAuth.Core.Usecases.CreateUser.Interfaces;

public interface ICreateUserStorage : IScopedService
{
    Task<int> CountUsers();
    Task CreateUsers(IEnumerable<CreateUserModel> users);
}
