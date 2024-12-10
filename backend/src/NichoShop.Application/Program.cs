using NichoShop.Application.Extensions;
using NichoShop.Application.Middleware;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services
    .AddSetupOption(configuration)
    .AddApplicationServices(configuration)
    .AddInfrastructureServices(configuration);

// Thêm filter vào MVC
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiResponseFilter>();
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.UseCors("_myAllowSpecificOrigins");
app.MapControllers();

app.Run();
