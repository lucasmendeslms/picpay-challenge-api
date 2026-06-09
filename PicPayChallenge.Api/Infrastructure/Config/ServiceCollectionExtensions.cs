using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using PicPayChallenge.Api.Config.Database;
using PicPayChallenge.Api.Repositories;
using PicPayChallenge.Api.Repositories.Interfaces;
using PicPayChallenge.Api.Services;
using PicPayChallenge.Api.Services.Interfaces;

namespace PicPayChallenge.Api.Config;

public static class ServiceCollectionExtensions
{
    extension(WebApplicationBuilder builder)
    {
        public WebApplicationBuilder RegisterAppDependencies()
        {
            builder.AddDatabaseConfiguration()
                .AddSwaggerConfiguration()
                .AddServiceItems();

            builder.Services.AddControllers();

            return builder;
        }

        /*private WebApplicationBuilder AddAppSettings()
        {
            builder.Services.Configure<>(
                builder.Configuration.GetSection("AppSettings"));
        
            return builder;
        }*/

        private WebApplicationBuilder AddDatabaseConfiguration()
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                   ?? throw new InvalidOperationException("Database connection string is missing or invalid.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            return builder;
        }

        private WebApplicationBuilder AddSwaggerConfiguration()
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

        private WebApplicationBuilder AddServiceItems()
        {
            return builder;
        }
    }
}