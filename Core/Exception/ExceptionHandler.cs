using Infra.Exception;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Exception;

public class ExceptionHandler(ILogger<ExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
    {
        int statusCode;
        switch (exception)
        {
            case NotFoundException:
                logger.LogWarning(exception.Message, "Not found exception");
                statusCode = StatusCodes.Status404NotFound;
                break;
            case UnauthorizedAccessException:
                logger.LogWarning(exception.Message, "Unauthorized access exception");
                statusCode = StatusCodes.Status401Unauthorized;
                break;
            default:
                statusCode = StatusCodes.Status500InternalServerError;
                logger.LogWarning(exception, "An unexpected error occurred");
                break;
        }
        
        var model = new ExceptionModel
        {
            Code = "1000",
            Message = exception.Message,
        };

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response
            .WriteAsJsonAsync(model, cancellationToken);

        return true;
    }
}

