using KhaiMarket.Server.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KhaiMarket.Server.Features.Products;

public static partial class ProductEndPoint
{
    private static async Task<Results<Ok<Product>, ProblemHttpResult>> GetProductById(
        GetProductByIdService productService,
        int id)
    {
        var result = await productService.GetProductById(id);
        if (result.IsError)
        {
            return TypedResults.Problem(
                statusCode: int.Parse(result.FirstError.Code),
                detail: result.FirstError.Description);
        }

        return TypedResults.Ok(result.Value);
    }
}
