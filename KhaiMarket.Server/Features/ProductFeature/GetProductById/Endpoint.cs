using KhaiMarket.Server.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KhaiMarket.Server.Features.ProductFeature;

public static partial class ProductEndPoint
{
    public static void MapProductEndPoint(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("api/products")
            .WithOpenApi()
            .WithTags("Products");

        endpoints.MapGet("/{id:int}", GetProductById);
    }

    private static async Task<Results<Ok<Product>, ProblemHttpResult>> GetProductById(
        [FromServices] GetProductService productService,
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
