﻿using FluentValidation;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.User;
using NichoShop.Application.Services;
using NichoShop.Application.Validators.User;
using NichoShop.Infrastructure.Authentication;
using NichoShop.Infrastructure.CommonService;
using NichoShop.Infrastructure.Context;

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
}
