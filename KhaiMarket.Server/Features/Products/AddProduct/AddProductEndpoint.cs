using FluentValidation;
using KhaiMarket.Server.Entities;
using KhaiMarket.Server.Features.Products.AddProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KhaiMarket.Server.Features.Products;

public static partial class ProductEndPoint
{
    private static async
        Task<Results<CreatedAtRoute<Product>, ValidationProblem>>
    AddProduct(
        AddProductService productService,
        AddProductRequest product)
    {
        var result = await productService.AddProduct(product);

        return TypedResults.CreatedAtRoute(
            value: result.Value,
            routeName: nameof(GetProductById),
            routeValues: result.Value.Id);
    }
}
