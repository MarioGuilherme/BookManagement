using BookManagement.Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace BookManagement.API.ExceptionHandler;

public class ApiExceptionHandler(ILogger<ApiExceptionHandler> logger) : IExceptionHandler {
    private readonly ILogger<ApiExceptionHandler> _logger = logger;

    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken) {
        httpContext.Response.StatusCode = exception switch {
            BookNotFoundException or LoanNotFoundException => StatusCodes.Status404NotFound,
            BookWithPendentLoanException => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError,
        };

        this._logger.LogError("{Message}", exception.Message);

        return ValueTask.FromResult(true);
    }
}