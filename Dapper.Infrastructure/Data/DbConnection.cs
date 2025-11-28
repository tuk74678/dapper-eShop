using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Dapper.Infrastructure.Data;

public class DbConnection
{
    public SqlConnection GetConnection()
    {
        var conn = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("eShopDb");
        return new SqlConnection(conn);
    }
}