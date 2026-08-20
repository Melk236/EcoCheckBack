using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EcoCheck.Infrastructure.Interceptors;

public class MySqlPrimaryKeyInterceptor : DbConnectionInterceptor
{
    public override async Task ConnectionOpenedAsync(
        DbConnection connection,
        ConnectionEndEventData eventData,
        CancellationToken cancellationToken = default)
    {
        await using var cmd = connection.CreateCommand();
        cmd.CommandText = "SET sql_require_primary_key = 0;";
        await cmd.ExecuteNonQueryAsync(cancellationToken);
    }

    public override void ConnectionOpened(
        DbConnection connection,
        ConnectionEndEventData eventData)
    {
        using var cmd = connection.CreateCommand();
        cmd.CommandText = "SET sql_require_primary_key = 0;";
        cmd.ExecuteNonQuery();
    }
}
