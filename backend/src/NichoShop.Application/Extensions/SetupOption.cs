using NichoShop.Application.Models.AppSettings;

namespace NichoShop.Application.Extensions;

public static class SetupOption
{
    public static IServiceCollection AddSetupOption(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
        return services;
    }
}
