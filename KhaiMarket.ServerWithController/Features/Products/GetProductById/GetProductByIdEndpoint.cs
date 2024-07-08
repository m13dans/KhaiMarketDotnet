
using KhaiMarket.ServerWithController.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KhaiMarket.ServerWithController.Features.Products;

public partial class ProductsController : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetProductById([FromServices] GetProductByIdService service, int id)
    {
        var result = await service.GetProductById(id);
        if (result.IsError)
        {
            return Results.Problem(
                statusCode: int.Parse(result.FirstError.Code),
                detail: result.FirstError.Description);
        }

        return Results.Ok(result.Value);
    }
}