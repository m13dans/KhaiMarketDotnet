using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhaiMarket.Server.Features.ProductFeature.AddProduct;

namespace KhaiMarket.Server.Features.ProductFeature;

public static class RegisterProductService
{
    public static void AddProductServices(this IServiceCollection services)
    {
        services.AddTransient<GetProductByIdService>();
        services.AddTransient<AddProductService>();
        services.AddTransient<ValidateProductService>();
    }
}
