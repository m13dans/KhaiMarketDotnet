using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace KhaiMarket.ServerWithController.Infrastructure;

public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly IConfiguration _config;
    private readonly string _connectionString;

    public DbConnectionFactory(IConfiguration config)
    {
        _config = config;
        _connectionString = config.GetConnectionString("SQLExpress")!;
    }
    public IDbConnection CreateOpenConnection() =>
        new SqlConnection(_connectionString);
}
