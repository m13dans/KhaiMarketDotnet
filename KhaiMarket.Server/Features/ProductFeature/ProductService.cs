using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhaiMarket.Server.Features.ProductFeature.AddProduct;

namespace KhaiMarket.Server.Features.ProductFeature;

public static class ProductService
{
    public static void AddProductServices(this IServiceCollection services)
    {
        services.AddTransient<GetProductService>();
        services.AddTransient<AddProductService>();
        services.AddTransient<CheckCategoryService>();
    }
}
