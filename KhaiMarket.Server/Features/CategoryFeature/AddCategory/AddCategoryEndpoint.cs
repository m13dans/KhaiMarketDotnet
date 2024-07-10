using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhaiMarket.Server.Features.CategoryFeature.AddCategory;
using Microsoft.AspNetCore.Http.HttpResults;

namespace KhaiMarket.Server.Features.CategoryFeature;

public static partial class CategoryEndPoint
{
    private static async Task<Results<Created, ValidationProblem>> AddCategory(
        AddCategoryService service,
        AddCategoryRequest request)
    {
        var result = await service.AddCategory(request.Name);

        return TypedResults.Created();
    }
}
