namespace NichoShop.Application.Models.Dtos.Request.ShoppingCart
{
    public class AddItemToCartRequestDto
    {
        public int ProductId { get; set; }
        public string SkuNo { get; set; }
        public int Quantity { get; set; }
    }
}
