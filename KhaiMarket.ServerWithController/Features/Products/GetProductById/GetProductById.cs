using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ErrorOr;
using KhaiMarket.ServerWithController.Entities;
using KhaiMarket.ServerWithController.Infrastructure;

namespace KhaiMarket.ServerWithController.Features.Products;

public class GetProductByIdService
{
    private readonly IDbConnectionFactory _db;
    public GetProductByIdService(IDbConnectionFactory db)
    {
        _db = db;
    }

    public async Task<ErrorOr<Product>> GetProductById(int id)
    {
        var sql = "SELECT * FROM Products WHERE Id = @id";
        using var connection = _db.CreateOpenConnection();
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
