namespace GiftShop.Services.Order.Contracts
{
    using GiftShop.Web.ViewModels.Cart;
    using GiftShop.Web.ViewModels.Order;
    public interface IOrderService
    {
        public Task<OrderViewModel> FillOrderViewModel(CartViewModel cartViewModel);
        public Task AddOrder(OrderViewModel order, string userId);
    }
}
