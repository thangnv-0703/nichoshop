using MediatR;
using NichoShop.Domain.SeedWork;
using NichoShop.TestDataLoader.Features;

namespace NichoShop.TestDataLoader;
public class MenuOption(int id, string name, IRequest command) : Enumeration(id, name)
{
    public IRequest Command { get; set; } = command;
    public static readonly MenuOption LoadCategoyDataFromSql = 
        new(1, "Load categoy data from sql", new LoadDataFromSqlCommand() { FileName = "category.sql" });
    public static readonly MenuOption LoadLocationDataFromSql = 
        new(2, "Load location data from sql", new LoadDataFromSqlCommand() { FileName = "location.sql" });
    public static readonly MenuOption SyncShoppeData = new(3, "Sync shoppe data", new SyncShoppeDataCommand());
}
