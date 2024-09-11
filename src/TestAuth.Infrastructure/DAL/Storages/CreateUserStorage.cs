using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using TestAuth.Core.Services;
using TestAuth.Core.Usecases.CreateUser.Interfaces;
using TestAuth.Core.Usecases.CreateUser.Models;

namespace TestAuth.Infrastructure.DAL.Storages;

public class CreateUserStorage(IAppSettings settings) : ICreateUserStorage
{
    private readonly IDbConnection _conn = new SqlConnection(settings.ConnectionString);

    public async Task<int> CountUsers()
    {
        const string query = "select count(*) from users";
        return await _conn.ExecuteScalarAsync<int>(query);
    }

    public async Task CreateUsers(IEnumerable<CreateUserRequest> request)
    {
        const string query = "insert into users (username,password_salt, password_hash, is_active) VALUES (@Name, @Salt, @Hash, @IsActive)";
        var users = request.Select(x => new
        {
            Name = x.Username,
            Salt = x.PasswordSalt,
            Hash = x.PasswordHash,
            IsActive = true
        });

        await _conn.ExecuteAsync(query, users);
    }
}
