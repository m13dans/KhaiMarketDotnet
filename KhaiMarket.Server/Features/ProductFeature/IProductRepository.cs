using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using KhaiMarket.Server.Entities;

namespace KhaiMarket.Server.Features.ProductFeature;

public partial interface IProductRepository
{
    public Task<IAsyncEnumerable<Product>> GetProductWithPagination();

    public Task AddProduct(Product product);
    public Task UpdateProduct(Product product);
    public Task DeleteProduct(int id);
}
