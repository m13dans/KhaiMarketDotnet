using KhaiMarket.Server.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KhaiMarket.Server.Features.ProductFeature;

public static partial class ProductEndPoint
{
    private static async Task<Results<Ok<List<Product>>, ProblemHttpResult>> GetProducts(
        GetProductsService productService)
    {
        var result = await productService.GetProducts();
        if (result.IsError)
        {
            return TypedResults.Problem(
                statusCode: int.Parse(result.FirstError.Code),
                detail: result.FirstError.Description);
        }

        return TypedResults.Ok(result.Value);
    }
}