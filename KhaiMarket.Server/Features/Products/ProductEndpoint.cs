using KhaiMarket.Server.Entities;
using KhaiMarket.Server.Features.Products.AddProduct;
using KhaiMarket.Server.Filters;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KhaiMarket.Server.Features.Products;

public static partial class ProductEndPoint
{
    public static void MapProductEndPoint(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("api/products")
            .WithOpenApi()
            .WithTags("Products");

        endpoints.MapGet("", GetProducts)
            .ProducesProblem(404, "application/problem+json");
        endpoints.MapGet("/{id:int}", GetProductById)
            .ProducesProblem(404, "application/problem+json");

        endpoints.MapPost("", AddProduct)
            .AddEndpointFilter<ValidationFilter<AddProductRequest>>();
    }
}
