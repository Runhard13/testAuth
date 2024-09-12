using System.Data;
using Dapper;
using Npgsql;
using TestAuth.Core.Services;
using TestAuth.Core.Usecases.Login.Interfaces;
using TestAuth.Core.Usecases.Login.Models;
using TestAuth.Infrastructure.DAL.Entities;

namespace TestAuth.Infrastructure.DAL.Storages;

public class LoginStorage(IAppSettings settings) : ILoginStorage
{
    public async Task<UserModel?> GetUserByUsername(string username)
    {
        using IDbConnection conn = new NpgsqlConnection(settings.ConnectionString);

        const string query = "select id, password_hash, password_salt, is_active from users where username = @UserName";
        var parameters = new
        {
            UserName = username
        };

        var user = await conn.QuerySingleOrDefaultAsync<User>(query, parameters);

        return user == null
            ? null
            : new UserModel(user.Id, user.PasswordSalt, user.PasswordHash, user.IsActive);
    }
}
