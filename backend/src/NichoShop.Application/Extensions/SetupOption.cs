﻿using NichoShop.Application.Models.AppSettings;
using NichoShop.Commons.Models;

namespace NichoShop.Application.Extensions;

public static class SetupOption
{
    public static IServiceCollection AddSetupOption(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
        services.Configure<AppConfig>(configuration.GetSection(nameof(AppConfig)));
        return services;
    }
}
