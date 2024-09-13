using System.Data;
using Dapper;
using Npgsql;
using TestAuth.Core.Services;
using TestAuth.Core.Usecases.CreateUser.Interfaces;
using TestAuth.Core.Usecases.CreateUser.Models;

namespace TestAuth.Infrastructure.DAL.Storages;

public class CreateUserStorage(IAppSettings settings) : ICreateUserStorage
{

    public async Task<int> CountUsers()
    {
        using IDbConnection conn = new NpgsqlConnection(settings.ConnectionString);
        const string query = "select count(*) from users";
        return await conn.ExecuteScalarAsync<int>(query);
    }

    public async Task CreateUsers(IEnumerable<CreateUserModel> users)
    {
        using IDbConnection conn = new NpgsqlConnection(settings.ConnectionString);
        const string query = "insert into users (username,password_salt, password_hash, is_active) VALUES (@Name, @Salt, @Hash, @IsActive)";
        var queryParam = users.Select(x => new
        {
            Name = x.Username,
            Salt = x.PasswordSalt,
            Hash = x.PasswordHash,
            IsActive = true
        });

        await conn.ExecuteAsync(query, queryParam);
    }
}
