using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace KhaiMarket.Server.Middleware;

public class GlobalExeption : IExceptionHandler
{
    private readonly ILogger<GlobalExeption> _logger;
    public GlobalExeption(ILogger<GlobalExeption> logger)
    {
        _logger = logger;

    }
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is BadHttpRequestException badHttpRequestException)
        {
            var problemDetailBadRequest = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
                Title = "One or more validation errors occurred.",
                Status = StatusCodes.Status400BadRequest,
                Detail = "One or more validation errors occurred please check your request body."
            };

            _logger.LogError(exception, "Exeption Occured: {Message}", badHttpRequestException.Message);
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(problemDetailBadRequest, cancellationToken: cancellationToken);
            return true;
        }

        var problemDetail = new ProblemDetails
        {
            Title = "Internal Server Error",
            Status = StatusCodes.Status500InternalServerError
        };

        _logger.LogError(exception, "Exeption Occured: {Message}", exception.Message);

        await httpContext.Response.WriteAsJsonAsync(problemDetail, cancellationToken: cancellationToken);
        return true;
    }
}
