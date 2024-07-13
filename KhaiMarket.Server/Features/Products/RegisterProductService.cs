using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhaiMarket.Server.Features.Products.AddProduct;

namespace KhaiMarket.Server.Features.Products;

public static class RegisterProductService
{
    public static void AddProductServices(this IServiceCollection services)
    {
        services.AddTransient<GetProductsService>();
        services.AddTransient<GetProductByIdService>();
        services.AddTransient<AddProductService>();
    }
}
