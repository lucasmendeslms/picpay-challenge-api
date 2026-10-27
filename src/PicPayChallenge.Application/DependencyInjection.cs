using Microsoft.Extensions.DependencyInjection;
using PicPayChallenge.Application.Interfaces.Services;
using PicPayChallenge.Application.Services;

namespace PicPayChallenge.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddServices();
        
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ILedgerService, LedgerService>();
        
        return services;
    }
}