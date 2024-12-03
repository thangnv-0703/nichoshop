using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            Console.Write("Do you want to update categories? (yes/no): ");
            string userInput = Console.ReadLine()?.Trim().ToLower();

            if (userInput == "yes")
            {
                await UpdateCategoryData();
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task UpdateCategoryData()
    {
        string jsonFilePath = "categories.json"; // Path to your JSON file
                                                 // Read JSON file
        string jsonContent = File.ReadAllText(jsonFilePath);
        var categories = JsonConvert.DeserializeObject<List<Category>>(jsonContent);

        using var context = new AppDbContext();
        if (categories != null)
        {
            context.Categories.RemoveRange(context.Categories);  
            await context.SaveChangesAsync();

            // Prepare batch insert
            var newCategories = new List<Category>();

            foreach (var category in categories)
            {
                InsertCategory(category);
            }
        }
        else
        {
            Console.WriteLine("No categories to insert.");
        }

        void InsertCategory(Category category)
        {
            context.Add(category);
            foreach (var childCategory in category.Children)
            {
                InsertCategory(childCategory);
            }
        }

        await context.SaveChangesAsync();
    }

}

[Table("categories")]
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [JsonProperty("display_name")]
    public string DisplayName { get; set; } = string.Empty;
    public int? ParentId { get; set; }  // Nullable to allow root categories
    [NotMapped]
    public Category? Parent { get; set; }
    [NotMapped]
    public ICollection<Category> Children { get; set; } = [];
}

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Host=localhost;Database=NichoShopDB;Username=postgres;Password=postgres";
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasOne(c => c.Parent)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}


