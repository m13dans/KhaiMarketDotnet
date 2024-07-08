using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ErrorOr;
using KhaiMarket.Server.Entities;
using KhaiMarket.Server.Infrastructure;

namespace KhaiMarket.Server.Features.ProductFeature;

public class GetProductsService(IDbConnectionFactory db)
{
    private readonly IDbConnectionFactory _db = db;
    public async Task<ErrorOr<List<Product>>> GetProducts()
    {
        var sql = "SELECT * FROM Products";
        var connection = _db.CreateOpenConnection();
        var result = await connection.QueryAsync<Product>(sql, param: new { });

        if (result is null)
        {
            var error = Error.NotFound(
                code: "404",
                description: $"There is no product in here");
            return error;
        }

        var products = result.ToList();
        return products;
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