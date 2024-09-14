using System.Data;
using Dapper;
using Npgsql;
using TestAuth.Core.Services;
using TestAuth.Core.Usecases.GetCurrentUser.Models;
using TestAuth.Core.Usecases.UpdateUser.Interfaces;
using TestAuth.Core.Usecases.UpdateUser.Models;
using TestAuth.Infrastructure.DAL.Entities;

namespace TestAuth.Infrastructure.DAL.Storages;

public class UpdateUserStorage(IAppSettings settings) : IUpdateUserStorage
{

    public async Task<UserModel?> GetUserById(Guid id)
    {
        using IDbConnection conn = new NpgsqlConnection(settings.ConnectionString);

        const string query = "select id from users where id = @UserId";
        var parameters = new
        {
            UserId = id
        };

        var user = await conn.QuerySingleOrDefaultAsync<User>(query, parameters);

        return user == null
            ? null
            : new UserModel(user.Id);
    }

    public async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request)
    {
        using IDbConnection conn = new NpgsqlConnection(settings.ConnectionString);

        const string query = "update users set is_active = @IsActive where id = @UserId";
        var parameters = new
        {
            request.UserId,
            request.IsActive
        };

        await conn.ExecuteAsync(query, parameters);

        return new UpdateUserResponse(request.UserId, request.IsActive);
    }
}
