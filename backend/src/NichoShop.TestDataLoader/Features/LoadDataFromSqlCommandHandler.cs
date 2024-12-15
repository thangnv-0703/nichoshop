using MediatR;
using Microsoft.EntityFrameworkCore;
using NichoShop.Infrastructure;

namespace NichoShop.TestDataLoader.Features;

public record LoadDataFromSqlCommand : IRequest
{
    public string FileName { get; set; } = string.Empty;
}

public class LoadDataFromSqlCommandHandler(NichoShopDbContext context) : IRequestHandler<LoadDataFromSqlCommand>
{
    private readonly NichoShopDbContext _context = context;
    public async Task Handle(LoadDataFromSqlCommand command, CancellationToken cancellationToken)
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string fileName = command.FileName;
        string sqlFilePath = Path.Combine(basePath, "Sql", fileName);

        if (!File.Exists(sqlFilePath))
        {
            Console.WriteLine("SQL file not found.");
        }

        try
        {
            // Read the SQL file
            string sql = File.ReadAllText(sqlFilePath);

            // Execute the SQL
            await _context.Database.ExecuteSqlRawAsync(sql, cancellationToken: cancellationToken);

            Console.WriteLine($"SQL script in {fileName} executed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while executing the SQL script: {ex.Message}");
        }
    }
}
