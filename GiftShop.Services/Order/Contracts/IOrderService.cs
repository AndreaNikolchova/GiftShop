namespace GiftShop.Services.Order.Contracts
{
    using GiftShop.Web.ViewModels.Cart;
    using GiftShop.Web.ViewModels.Order;
    public interface IOrderService
    {
        public OrderViewModel FillOrderViewModel(CartViewModel cartViewModel);
    }
}
