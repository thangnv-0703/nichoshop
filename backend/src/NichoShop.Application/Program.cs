﻿using NichoShop.Application.Extensions;
using NichoShop.Application.Mappers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services
    .AddSetupOption(configuration)
    .AddApplicationServices(configuration)
    .AddInfrastructureServices(configuration)
    .AddAutoMapper(typeof(AutoMapperProfiles));

LoggingSetup.ConfigureLogging(builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("_myAllowSpecificOrigins");
app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();

app.Run();



