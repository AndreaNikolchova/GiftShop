namespace GiftShop.ViewModels.Product
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }    
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string Type { get; set; } = null!;
    }
}
