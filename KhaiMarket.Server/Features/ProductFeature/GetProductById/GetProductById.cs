using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ErrorOr;
using KhaiMarket.Server.Entities;
using KhaiMarket.Server.Infrastructure;

namespace KhaiMarket.Server.Features.ProductFeature;

public class GetProductByIdService(IDbConnectionFactory db)
{
    private readonly IDbConnectionFactory _db = db;
    public async Task<ErrorOr<Product>> GetProductById(int id)
    {
        var sql = "SELECT * FROM Products WHERE Id = @id";
        var connection = _db.CreateOpenConnection();
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


/* public partial class ProductRepository : IProductRepository
{
    Task<IAsyncEnumerable<Product>> IProductRepository.GetProductWithPagination()
    {
        throw new NotImplementedException();
    }
}
public partial class ProductRepository : IProductRepository
{
    public async Task AddProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
public partial class ProductRepository : IProductRepository
{
    public async Task UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
public partial class ProductRepository : IProductRepository
{
    public async Task DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }
}
 */