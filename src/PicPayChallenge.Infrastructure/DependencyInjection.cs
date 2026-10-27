using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PicPayChallenge.Infrastructure.Data;
using PicPayChallenge.Application.Interfaces.Repositories;
using PicPayChallenge.Application.Interfaces.Common;
using PicPayChallenge.Infrastructure.Data.Repositories;

namespace PicPayChallenge.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddPersistence(configuration)
            .AddRepositories();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException("Database connection string is missing or invalid.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));


        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();

        return services;
    }
}


/*private WebApplicationBuilder AddAppSettings()
      {
          builder.Services.Configure<>(
              builder.Configuration.GetSection("AppSettings"));

          return builder;
      }*/
