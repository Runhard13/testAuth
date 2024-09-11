using TestAuth.Core.Usecases.GetUsers.Interfaces;
using TestAuth.Core.Usecases.GetUsers.Models;

namespace TestAuth.Infrastructure.DAL.Storages;

public class GetUsersStorage : IGetUsersStorage
{
    public Task<List<UserModel>> GetUsers() => throw new NotImplementedException();
}
