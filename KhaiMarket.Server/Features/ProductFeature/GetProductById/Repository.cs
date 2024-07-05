using Dapper;
using ErrorOr;
using KhaiMarket.Server.Entities;
using KhaiMarket.Server.Infrastructure;

namespace KhaiMarket.Server.Features.ProductFeature;
public class GetProductRepository
{
    private readonly IDbConnectionFactory _dbConnection;
    public GetProductRepository(IDbConnectionFactory dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<ErrorOr<Product>> GetProductById(int id)
    {
        var sql = "SELECT * FROM Products WHERE Id = @id";
        var connection = _dbConnection.CreateOpenConnection();
        var result = await connection.QuerySingleOrDefaultAsync<Product>(sql, param: new { id });

        if (result is null)
        {
            var error = Error.NotFound(
                code: "404",
                description: $"Product with id {id} cannot be found");
            return error;
        }

        return result;
    }

}