using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.User;
using NichoShop.Application.Services;
using NichoShop.Application.Validators.User;
using NichoShop.Application.CommonService.Implementation;
using NichoShop.Application.CommonService.Interface;
using System.Text;
using NichoShop.Application.Models.AppSettings;
using NichoShop.Application.Queries;

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
        return services;
    }

    private static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
    
    private static IServiceCollection ConfigureFluentValidation(this IServiceCollection services) {
        services.AddScoped<IValidator<CreateUserRequestDto>, CreateUserValidator>();
        services.AddScoped<IValidator<LoginRequestDto>, LoginValidator>();
        return services;
    }

    private static IServiceCollection ConfigureApplicationService(this IServiceCollection services) {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }

    private static IServiceCollection ConfigureCustomService(this IServiceCollection services) {
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

    public static IServiceCollection ConfigureQuery(this IServiceCollection services)
    {
        services.AddScoped<IQueryService, QueryService>();
        return services;
    }
}
