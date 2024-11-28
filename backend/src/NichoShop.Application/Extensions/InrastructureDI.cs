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
        services.AddDbContext<NichoShopDbContext>(options =>
            //options.UseNpgsql(configuration["ConnectionStrings"], b => b.MigrationsAssembly("NichoShop.Application")));
            options.UseNpgsql(configuration.GetConnectionString("NichoShopDB"), b => b.MigrationsAssembly("NichoShop.Application")));

        return services;
    }
}
