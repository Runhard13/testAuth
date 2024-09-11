using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using TestAuth.Core.Services;
using TestAuth.Core.Usecases.GetCurrentUser.Interfaces;
using TestAuth.Core.Usecases.GetCurrentUser.Models;
using TestAuth.Infrastructure.DAL.Entities;

namespace TestAuth.Infrastructure.DAL.Storages;

public class GetCurrentUserStorage(IAppSettings settings) : IGetCurrentUserStorage
{

    public async Task<GetCurrentUserResponse?> GetUserById(Guid id)
    {
        using IDbConnection conn = new SqlConnection(settings.ConnectionString);

        const string query = "select id, username, is_active from users where id = @UserId";
        var parameters = new
        {
            UserId = id
        };

        var user = await conn.QuerySingleOrDefaultAsync<User>(query, parameters);

        return user == null
            ? null
            : new GetCurrentUserResponse(user.Id, user.Username, user.IsActive);

    }
}
