using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using KhaiMarket.Server.Entities;
using KhaiMarket.Server.Features.CategoryFeature.GetAllCategory;
using Microsoft.AspNetCore.Http.HttpResults;

namespace KhaiMarket.Server.Features.CategoryFeature;

public static partial class CategoryEndPoint
{
    private static async Task<Results<Ok<List<Category>>, ProblemHttpResult>> GetAllCategory(GetAllCategoryService service)
    {
        ErrorOr<List<Category>> result = await service.GetAllCategory();

        if (result.IsError)
        {
            return TypedResults.Problem(statusCode: StatusCodes.Status404NotFound);
        }

        return TypedResults.Ok(result.Value);
    }
}
