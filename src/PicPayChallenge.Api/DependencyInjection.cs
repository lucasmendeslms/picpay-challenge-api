using Microsoft.OpenApi;
using PicPayChallenge.Api.Handlers;

namespace PicPayChallenge.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddSwagger();
        services.AddControllers();
        services.AddErrorHandling();
        
        return services;
    }

    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "PicPay Challenge",
                Description = "PicPay Challenge API",
                Version = "v3"
            });
        });

        return services;
    }

    private static IServiceCollection AddErrorHandling(this IServiceCollection services)
    {
        services.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = ctx =>
            {
                ctx.ProblemDetails.Extensions["detail"] = null;
                ctx.ProblemDetails.Extensions["instance"] = ctx.HttpContext.Request.Path.Value;
                ctx.ProblemDetails.Extensions["traceId"] = ctx.HttpContext.TraceIdentifier;
                ctx.ProblemDetails.Extensions["timestamp"] = DateTime.UtcNow;
            };
        });

        services.AddExceptionHandler<GlobalExceptionHandler>();

        return services;
    }
}