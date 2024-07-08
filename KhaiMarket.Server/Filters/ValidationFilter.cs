using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace KhaiMarket.Server.Filters;

public class ValidationFilter<TRequest> : IEndpointFilter
{
    private readonly IValidator<TRequest> _validator;
    public ValidationFilter(IValidator<TRequest> validator)
    {
        _validator = validator;

    }
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var request = context.Arguments.OfType<TRequest>().First();

        var validationContext = new ValidationContext(request!);
        var validationResult = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request!, validationContext, validationResult, true);
        if (!isValid)
        {
            return TypedResults.Problem();
        }

        var result = await _validator.ValidateAsync(request, context.HttpContext.RequestAborted);

        if (!result.IsValid)
        {
            return TypedResults.ValidationProblem(result.ToDictionary());
        }

        return await next(context);
    }
}
