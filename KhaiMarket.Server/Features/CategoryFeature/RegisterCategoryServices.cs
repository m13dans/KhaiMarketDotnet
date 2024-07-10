using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhaiMarket.Server.Features.CategoryFeature.AddCategory;
using KhaiMarket.Server.Features.CategoryFeature.GetAllCategory;

namespace KhaiMarket.Server.Features.CategoryFeature;

public static class RegisterCategoryService
{
    public static void AddCategoryServices(this IServiceCollection services)
    {
        services.AddTransient<AddCategoryService>();
        services.AddTransient<GetAllCategoryService>();
        services.AddTransient<CategoryValidatorService>();
    }
}
