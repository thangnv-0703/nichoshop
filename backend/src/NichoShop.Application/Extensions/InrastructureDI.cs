using Microsoft.EntityFrameworkCore;
using NichoShop.Infrastructure;

namespace NichoShop.Application.Extensions;

public static class InrastructureDI
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCustomDbContext(configuration);
        return services;
    }

    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEntityFrameworkSqlServer()
               .AddDbContext<NichoShopDbContext>(options =>
               {
                   options.UseSqlServer(configuration["ConnectionString"],
                       sqlServerOptionsAction: sqlOptions =>
                       {
                           sqlOptions.MigrationsAssembly("NichoShop.Application");
                           sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                       });
               },
                   ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
               );

        return services;
    }
}
