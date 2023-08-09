namespace GiftShop.Services.Order
{
    using GiftShop.Services.Order.Contracts;
    using GiftShop.Web.ViewModels.Cart;
    using GiftShop.Web.ViewModels.Customer;
    using GiftShop.Web.ViewModels.Order;

    public class OrderService : IOrderService
    {
        public OrderViewModel FillOrderViewModel(CartViewModel cartViewModel)
        {
            var sum = 0m;
            foreach(var product in cartViewModel.Products)
            {
                sum+=decimal.Parse(product.Price)*product.Quantity;
            }
            var model = new OrderViewModel()
            {
                Cart = cartViewModel,
                Customer = new CustomerViewModel(),
                Sum = sum,
            };
            return model;
        }
    }
}
