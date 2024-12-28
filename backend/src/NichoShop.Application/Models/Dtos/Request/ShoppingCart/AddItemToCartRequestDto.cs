namespace NichoShop.Application.Models.Dtos.Request.ShoppingCart
{
    public class AddItemToCartRequestDto
    {
        public int ProductId { get; set; }
        public int SkuId { get; set; }
        public int Quantity { get; set; }
    }
}
