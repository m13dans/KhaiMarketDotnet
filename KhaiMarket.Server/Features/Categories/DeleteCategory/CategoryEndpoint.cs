using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using KhaiMarket.Server.Features.Categories.DeleteCategory;
using Microsoft.AspNetCore.Http.HttpResults;

namespace KhaiMarket.Server.Features.Categories;

public static partial class CategoryEndpoint
{
    public static async Task<Results<Ok, ProblemHttpResult>> DeleteCategory(
        DeleteCategoryService service,
        int id)
    {
        ErrorOr<Deleted> deleted = await service.DeleteCategoryAsync(id);

        var result = deleted.MatchFirst<Results<Ok, ProblemHttpResult>>(
            onValue: _ => TypedResults.Ok(),

            onFirstError: error => TypedResults.Problem(
                statusCode: StatusCodes.Status404NotFound,
                title: error.Code,
                detail: error.Description)
        );

        return result;
    }
}
