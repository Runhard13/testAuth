using System.Data;
using Dapper;
using Npgsql;
using TestAuth.Core.Services;
using TestAuth.Core.Usecases.GetUsers.Interfaces;
using TestAuth.Core.Usecases.GetUsers.Models;
using TestAuth.Infrastructure.DAL.Entities;

namespace TestAuth.Infrastructure.DAL.Storages;

public class GetUsersStorage(IAppSettings settings) : IGetUsersStorage
{
    public async Task<List<UserModel>> GetUsers()
    {
        using IDbConnection conn = new NpgsqlConnection(settings.ConnectionString);

        const string query = "select id, username, is_active from users";

        var users = await conn.QueryAsync<User>(query);

        return users
            .Select(x => new UserModel(x.Id, x.Username, x.IsActive))
            .ToList();
    }
}
