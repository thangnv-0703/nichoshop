using Microsoft.EntityFrameworkCore;
using NichoShop.Domain.Repositories;
using NichoShop.Infrastructure;
using NichoShop.Infrastructure.Repositories;

namespace NichoShop.Application.Extensions;

public static class InfrastructureDI
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigreDatabaseContext(configuration);
        services.ConfigureRepositories();
        return services;
    }

    public static IServiceCollection ConfigreDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NichoShopDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("NichoShopDB"), b => b.MigrationsAssembly("NichoShop.Application")));
        return services;
    }

    public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        return services;
    }
}
