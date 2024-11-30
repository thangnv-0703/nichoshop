using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using NichoShop.Infrastructure;

namespace NichoShop.Application.ContextFactory;

public class NichoShopDbContextFactory : IDesignTimeDbContextFactory<NichoShopDbContext>
{
    public NichoShopDbContext CreateDbContext(string[] args)
    {
        
        // Build configuration
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .Build();
        Console.WriteLine(environment);
        var optionsBuilder = new DbContextOptionsBuilder<NichoShopDbContext>();
        var connectionString = configuration.GetConnectionString("NichoShopDB");
        optionsBuilder.UseNpgsql(connectionString, b => b.MigrationsAssembly("NichoShop.Application"));

        return new NichoShopDbContext(optionsBuilder.Options, configuration);
    }
}