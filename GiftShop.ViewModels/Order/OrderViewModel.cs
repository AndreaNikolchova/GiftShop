namespace GiftShop.Web.ViewModels.Order
{
    using GiftShop.Web.ViewModels.Cart;
    using GiftShop.Web.ViewModels.Customer;

    public class OrderViewModel
    {
        public CartViewModel Cart { get; set; } = null!;
        public CustomerViewModel Customer { get; set; } = null!;
        public decimal Sum { get; set; } 
    }
}
