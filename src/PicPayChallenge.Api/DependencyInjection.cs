using Microsoft.OpenApi;

namespace PicPayChallenge.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddSwagger();
        services.AddControllers();

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
}