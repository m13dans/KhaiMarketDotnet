
using FluentValidation;
using KhaiMarket.ServerWithController.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KhaiMarket.ServerWithController.Features.Products;

public partial class ProductsController : ControllerBase
{
    private readonly IValidator<AddProductRequest> _validator;
    public ProductsController(IValidator<AddProductRequest> validator)
    {
        _validator = validator;

    }
    [HttpPost]
    [ProducesResponseType(typeof(Product), 201)]
    [ProducesResponseType(400)]
    public async Task<IResult> AddProduct(
        [FromServices] AddProductService service,
        AddProductRequest productRequest)
    {
        var validationResult = await _validator.ValidateAsync(productRequest);
        if (!ModelState.IsValid)
        {
            return Results.BadRequest();
        }
        if (!validationResult.IsValid)
        {
            return TypedResults.ValidationProblem(validationResult.ToDictionary());
            validationResult.AddToModelState(ModelState);

        }

        var result = await service.AddProduct(productRequest);
        if (result.IsError)
        {
            return TypedResults.Problem(
                statusCode: int.Parse(result.FirstError.Code),
                detail: result.FirstError.Description);
        }

        return TypedResults.CreatedAtRoute(
            value: result.Value,
            routeName: nameof(GetProductById),
            routeValues: result.Value.Id);
    }
}