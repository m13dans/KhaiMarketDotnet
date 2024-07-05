using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ErrorOr;
using KhaiMarket.Server.Entities;
using KhaiMarket.Server.Infrastructure;

namespace KhaiMarket.Server.Features.ProductFeature;

public class GetProductService(GetProductRepository repo)
{
    private readonly GetProductRepository _repo = repo;

    public async Task<ErrorOr<Product>> GetProductById(int id)
    {
        ErrorOr<Product> result = await _repo.GetProductById(id);
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