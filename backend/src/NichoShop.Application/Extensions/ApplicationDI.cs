using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.AppSettings;
using NichoShop.Application.Models.Dtos.Request.User;
using NichoShop.Application.Models.Dtos.Request.UserAddress;
using NichoShop.Application.Queries;
using NichoShop.Application.Services;
using NichoShop.Application.Validators.User;
using NichoShop.Application.Validators.UserAddress;
using NichoShop.Common.Interface;
using NichoShop.Common.Service;
using NichoShop.Commons.Models;
using System.Text;

namespace NichoShop.Application.Extensions;

public static class ApplicationDI
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.ConfigureSwagger();
        services.ConfigureApplicationService();
        services.ConfigureFluentValidation();
        services.ConfigureCustomService();
        services.ConfigureAuthencation(configuration);
        services.ConfigureQuery();
        services.ConfigureCors(configuration);
        return services;
    }

    private static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

    private static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateUserRequestDto>, CreateUserValidator>();
        services.AddScoped<IValidator<LoginRequestDto>, LoginValidator>();
        services.AddScoped<IValidator<UserAddressRequestDto>, UserAddressValidator>();
        return services;
    }

    private static IServiceCollection ConfigureApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IUserAddressService, UserAddressService>();
        services.AddScoped<ILocationService, LocationService>();
        services.AddScoped<IStorageService, AzureBlobStorageService>();
        services.AddScoped<IShoppingCartService, ShoppingCartService>();
        return services;
    }

    private static IServiceCollection ConfigureCustomService(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IUserContext, UserContext>();
        return services;
    }

    public static IServiceCollection ConfigureAuthencation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var jwtOption = serviceProvider.GetRequiredService<IOptions<JwtOptions>>().Value;
                options.TokenValidationParameters = new()
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

    public static IServiceCollection ConfigureCors(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceProvider = services.BuildServiceProvider();
        var appConfig = serviceProvider.GetRequiredService<IOptions<AppConfig>>().Value;

        if (appConfig.Cors != null)
        {
            services.AddCors(
            options =>
            {
                options.AddPolicy(
                    name: "_myAllowSpecificOrigins",
                    builder => builder.WithOrigins(appConfig.Cors)
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      .AllowCredentials()
                );
            });
        }
        return services;
    }

    public static IServiceCollection ConfigureQuery(this IServiceCollection services)
    {
        services.AddScoped<IQueryService, QueryService>();
        return services;
    }
}
