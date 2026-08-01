using Microsoft.AspNetCore.Diagnostics;

namespace PicPayChallenge.Api.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public GlobalExceptionHandler()
    {
        
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {

        return true;
    }
}