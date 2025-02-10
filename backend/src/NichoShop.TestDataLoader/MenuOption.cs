using MediatR;
using NichoShop.Domain.Enums;
using NichoShop.Domain.SeedWork;
using NichoShop.TestDataLoader.Features;

namespace NichoShop.TestDataLoader;
public class MenuOption(int id, string name, IRequest command) : Enumeration(id, name)
{
    public IRequest Command { get; set; } = command;

    public static readonly MenuOption SyncShoppeData =
        new(1, "Sync shoppe data", new SyncShoppeDataCommand());
    public static readonly MenuOption LoadCategoyDataFromSql =
        new(2, "Load data from sql", new LoadDataFromSqlCommand());
    public static readonly MenuOption CopyCategoryImageFromProductionToDev = 
        new(3, "Copy category image from production to dev", new CopyBlobStorageCommand() 
        { 
            IsCopyFromDevToProd = false, 
            StorageType = StorageType.CategoryImages
        });
}
