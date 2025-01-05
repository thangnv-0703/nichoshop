using NichoShop.Application.Extensions;
using NichoShop.Application.Mappers;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services
    .AddSetupOption(configuration)
    .AddApplicationServices(configuration)
    .AddInfrastructureServices(configuration)
    .AddAutoMapper(typeof(AutoMapperProfiles));

builder.Logging.ClearProviders();
builder.Host.UseNLog();

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
