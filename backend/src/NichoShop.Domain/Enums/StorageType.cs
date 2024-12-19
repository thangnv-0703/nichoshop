using System.ComponentModel.DataAnnotations;

namespace NichoShop.Domain.Enums;
public enum StorageType
{
    [Display(Name = "productimage")]
    ProductImages = 1,

    [Display(Name = "avatar")]
    Avatar = 2
}
