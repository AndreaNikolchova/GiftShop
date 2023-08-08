namespace GiftShop.Web.ViewModels.Cart
{
    using GiftShop.Web.ViewModels.Product;
    public class CartViewModel
    {
        public CartViewModel()
        {
            Products = new List<ProductViewModel>();
        }
        public List<ProductViewModel> Products { get; set; }
        public string? UserId { get; set; }
    }
}
