namespace Basket.Host.Entities
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string PetsFoodName { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
    }
}
