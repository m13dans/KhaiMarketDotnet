using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhaiMarket.Server.Features.Categories.AddCategory;
using KhaiMarket.Server.Features.Categories.DeleteCategory;
using KhaiMarket.Server.Features.Categories.GetAllCategory;

namespace KhaiMarket.Server.Features.Categories;

public static class RegisterCategoryService
{
    public static void AddCategoryServices(this IServiceCollection services)
    {
        services.AddTransient<AddCategoryService>();
        services.AddTransient<GetAllCategoryService>();
        services.AddTransient<DeleteCategoryService>();
    }
}
