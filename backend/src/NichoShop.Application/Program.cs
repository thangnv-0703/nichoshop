using NichoShop.Application.Extensions;
using NichoShop.Application.Mappers;

var builder = WebApplication.CreateBuilder(args);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

if (environment == "Development")
{
    builder.Configuration.AddAzureAppConfiguration(options =>
    {
        options.Connect("Endpoint=https://hivespace-appcfg.azconfig.io;Id=PPEz;Secret=6hmVeTio5FWXwrFM3U6Jyv8NLEFHJJMwwj54tLgbrq58U828aLzaJQQJ99BAAC3pKaRJiu6FAAABAZAC1Sdg");
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



