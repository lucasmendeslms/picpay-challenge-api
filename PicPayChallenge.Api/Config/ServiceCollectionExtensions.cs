using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PicPayChallenge.Api.Config;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder RegisterAppDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen()
            .AddControllers();

        return builder;
    }
}