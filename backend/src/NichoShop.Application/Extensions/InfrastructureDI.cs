using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NichoShop.Domain.Repositories;
using NichoShop.Infrastructure;
using NichoShop.Infrastructure.Authentication;
using NichoShop.Infrastructure.Repositories;
using System.Text;

namespace NichoShop.Application.Extensions;

public static class InfrastructureDI
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOption = configuration.GetSection("Jwt").Get<JwtOptions>()!;
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        services.ConfigreDbContext(configuration);
        services.ConfigureRepositories();
        services.ConfigureAuthencation(configuration);
        return services;
    }

    public static IServiceCollection ConfigreDbContext(this IServiceCollection services, IConfiguration configuration)
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

    public static IServiceCollection ConfigureAuthencation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var jwtOption = serviceProvider.GetRequiredService<IOptions<JwtOptions>>().Value;
                options.TokenValidationParameters = new ()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOption!.Issuer,
                    ValidAudience = jwtOption!.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOption.SecretKey))
                };
            });
        return services;
    }
}
