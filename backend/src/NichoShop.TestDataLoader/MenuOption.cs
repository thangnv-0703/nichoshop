using MediatR;
using NichoShop.Domain.SeedWork;
using NichoShop.TestDataLoader.Features;

namespace NichoShop.TestDataLoader;
public class MenuOption(int id, string name, IRequest command) : Enumeration(id, name)
{
    public IRequest Command { get; set; } = command;

    public static readonly MenuOption SyncShoppeData =
        new(1, "Sync shoppe data", new SyncShoppeDataCommand());

    public static readonly MenuOption LoadCategoyDataFromSql = 
        new(2, "Load categoy data from sql", new LoadDataFromSqlCommand() { FileName = "category.sql" });

    public static readonly MenuOption LoadLocationDataFromSql = 
        new(3, "Load location data from sql", new LoadDataFromSqlCommand() { FileName = "location.sql" });

    public static readonly MenuOption LoadAttributeDataFromSql = 
        new(4, "Load attribute data from sql", new LoadDataFromSqlCommand() { FileName = "attribute.sql" });

    public static readonly MenuOption LoadAttributeCategoryDataFromSql = 
        new(5, "Load attribute category data from sql", new LoadDataFromSqlCommand() { FileName = "attribute_category.sql" });

    public static readonly MenuOption LoadProductDataFromSql = 
        new(6, "Load product data from sql", new LoadDataFromSqlCommand() { FileName = "product.sql" });

    public static readonly MenuOption LoadSkuDataFromSql = 
        new(6, "Load sku data from sql", new LoadDataFromSqlCommand() { FileName = "sku.sql" });
}
