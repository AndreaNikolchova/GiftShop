namespace GiftShop.Services.Order
{
    using GiftShop.Data;
    using GiftShop.Services.Order.Contracts;
    using GiftShop.Web.ViewModels.Cart;
    using GiftShop.Web.ViewModels.Customer;
    using GiftShop.Web.ViewModels.Order;
    using GiftShop.Models;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using GiftShop.Web.ViewModels.Packaging;
    using GiftShop.Web.ViewModels.DeliveryCompany;

    public class OrderService : IOrderService
    {
        public GiftShopDbContext dbContext { get; set; }

        public OrderService(GiftShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task AddOrder(OrderViewModel orderViewModel, string userId)
        {
            Order order = new Order();
            var customer = dbContext.Customers.FirstOrDefault(x => x.UserId == userId);
            if (customer != null)
            {
                order.Customer = customer;
            }
            else
            {
                order.Customer = new Customer()
                {
                    FirstName = orderViewModel.Customer.FirstName,
                    LastName = orderViewModel.Customer.LastName,
                    Address = orderViewModel.Customer.Address,
                    TownName = orderViewModel.Customer.Town,
                    UserId = userId,
                };

            }
            throw new Exception();
        }

        public async Task<OrderViewModel> FillOrderViewModel(CartViewModel cartViewModel)
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
                Packagings = await this.dbContext.Packaging
                .Select(x=> new PackagingViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price=x.Price
                })
                .ToArrayAsync(),
                DeliveryCompanyNames = await this.dbContext.DeliveryCompanies
                .Select(x => new DeliveryCompanyViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                })
                .ToArrayAsync(),
            };
            return model;
           
        }
    }
}
