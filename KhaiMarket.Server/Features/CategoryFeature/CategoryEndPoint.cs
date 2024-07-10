using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using KhaiMarket.Server.Filters;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace KhaiMarket.Server.Features.CategoryFeature;

public static partial class CategoryEndPoint
{
    public static void MapCategoryEndpoint(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("api/categories").WithOpenApi().WithTags("Categories");

        endpoints.MapGet("", GetAllCategory);

        endpoints.MapPost("", AddCategory)
            .AddEndpointFilter<ValidationFilter<AddCategoryRequest>>();
    }
}