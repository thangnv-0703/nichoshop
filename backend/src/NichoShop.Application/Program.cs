using NichoShop.Application.Extensions;
using NichoShop.Application.Mappers;

var builder = WebApplication.CreateBuilder(args);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

if (environment == "Development")
{
    builder.Configuration.AddAzureAppConfiguration(options =>
    {
        options.Connect("Endpoint=https://nichoshop-app-configuraion.azconfig.io;Id=OI5h;Secret=50sUfcbZ6LAPoXV92kOhnYTu0BB8W7KGcVGfSPeSE9v6eWvgdVQJJQQJ99BAAC3pKaRJiu6FAAACAZAC18S3");
    });

    //builder.Configuration.AddAzureKeyVault(
    //    new Uri("<Key Vault URI>"),
    //    new DefaultAzureCredential());
}


var configuration = builder.Configuration;
Console.WriteLine(configuration["Test:Env"]);

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



