namespace GiftShop.Services.CustomOrder.Contracts
{
    using GiftShop.Web.ViewModels.CustomProduct;
    using GiftShop.Web.ViewModels.Order;

    public interface ICustomOrderService
    {
        public Task AddCustomOrderAsync(CustomRequestViewModel request, string email);
        public Task<IEnumerable<CustomOrderViewModel>> GetAllOrdersAsync();
        public Task MarkAnOrderAsDoneAsync(Guid orderId);
     
    }
}
