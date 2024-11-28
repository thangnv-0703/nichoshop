﻿using FluentValidation;
using NichoShop.Application.Models.Dtos.Request.User;
using NichoShop.Application.Validators.User;

namespace NichoShop.Application.Extensions;

public static class ApplicationDI
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.ConfigureSwagger();
        return services;
    }

    private static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

    private static IServiceCollection ConfigureValidator(this IServiceCollection services) {
        services.AddScoped<IValidator<CreateUserRequestDto>, CreateUserValidator>();
        return services;
    }
}
