using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using PicPayChallenge.Infrastructure.Data;
using PicPayChallenge.Application.Services.Interfaces;
using PicPayChallenge.Application.Services;

namespace PicPayChallenge.Infrastructure.Config;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder RegisterAppDependencies(this WebApplicationBuilder builder)
    {
        builder.AddDatabaseConfiguration()
            .AddSwaggerConfiguration()
            .AddServiceItems();

        builder.Services.AddControllers();

        return builder;
    }

    private static WebApplicationBuilder AddDatabaseConfiguration(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException("Database connection string is missing or invalid.");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        return builder;
    }

    private static WebApplicationBuilder AddSwaggerConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "PicPay Challenge API",
                Description = "PicPay Challenge API",
                Version = "v1"
            });
        });

        return builder;
    }

    private static WebApplicationBuilder AddServiceItems(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        return builder;
    }
}


/*private WebApplicationBuilder AddAppSettings()
      {
          builder.Services.Configure<>(
              builder.Configuration.GetSection("AppSettings"));

          return builder;
      }*/
