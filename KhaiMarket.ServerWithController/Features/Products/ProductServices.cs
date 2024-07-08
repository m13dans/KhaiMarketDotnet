using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhaiMarket.ServerWithController.Features.Products.AddProduct;

namespace KhaiMarket.ServerWithController.Features.Products;

public static class ProductServices
{
    public static void RegisterProductsServices(this IServiceCollection services)
    {
        services.AddTransient<GetProductByIdService>();
        services.AddTransient<AddProductService>();
        services.AddTransient<CheckCategoryService>();
    }
}
