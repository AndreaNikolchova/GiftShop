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
    using GiftShop.Services.EmailSender.Contracts;
    using static GiftShop.Common.EmailMessagesConstants;
    using GiftShop.Web.ViewModels.Product;

    public class OrderService : IOrderService
    {
        public GiftShopDbContext dbContext { get; set; }
        private IEmailSenderService emailSender;

        public OrderService(GiftShopDbContext dbContext, IEmailSenderService emailSender)
        {
            this.dbContext = dbContext;
            this.emailSender = emailSender;
        }

        public async Task AddOrder(OrderViewModel orderViewModel, string userId, string email)
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
            order.DeliveryCompany = await dbContext.DeliveryCompanies
                .FirstAsync(x => x.Price == orderViewModel.DeliveryCompany);
            var products = new List<OrderProduct>();
            var removeProducts = new List<Product>();
            var productIds = orderViewModel.Cart.Products.Select(x => x.Id).ToArray();
            foreach (var id in productIds)
            {
                products.Add(new OrderProduct()
                {
                    OrderId = order.Id,
                    ProductId = id,
                    Quantity = orderViewModel.Cart.Products.First(x => x.Id == id).Quantity
                });
                dbContext.Products.First(x => x.Id == id).Quantity -= orderViewModel.Cart.Products.First(x => x.Id == id).Quantity;

            }
            order.OrderProducts = products;
            order.Sum = orderViewModel.Sum;
            order.Packaging = await dbContext.Packaging
                .FirstAsync(x => x.Price == orderViewModel.Packaging);
            order.CreatedOn = DateTime.Now;

            var cart = await dbContext.Cart.FirstOrDefaultAsync(x => x.UserId == userId);
            await dbContext.Orders.AddAsync(order);
            await dbContext.OrderProducts.AddRangeAsync(products);
            dbContext.Cart.Remove(cart);
            await dbContext.SaveChangesAsync();
            emailSender.SendEmail(email, RecievedOrderSubject, RecievedCustomOrderBody, Ending);

        }

        public async Task<OrderViewModel> FillOrderViewModel(CartViewModel cartViewModel)
        {
            var sum = 0m;
            foreach (var product in cartViewModel.Products)
            {
                sum += decimal.Parse(product.Price) * product.Quantity;
            }
            var customer = new CustomerViewModel();
            if (this.dbContext.Customers.FirstOrDefault(x => x.UserId == cartViewModel.UserId) != null)
            {
                customer = await this.dbContext.Customers
                    .Where(x => x.UserId == cartViewModel.UserId)
                    .Select(x => new CustomerViewModel()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Town = x.TownName,
                        Address = x.Address
                    }).FirstAsync();
            }
            var model = new OrderViewModel()
            {
                Cart = cartViewModel,
                Customer = customer,
                Sum = sum,
                Packagings = await this.dbContext.Packaging
                .Select(x => new PackagingViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
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
        public async Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync()
        {
            var customOrders = await this.dbContext.Orders.Where(x => x.IsDone == false).OrderBy(x => x.CreatedOn).Select(x => new OrderViewModel()
            {
                Id = x.Id,
                Products = x.OrderProducts
                   .Where(p => p.OrderId == x.Id)
                   .Select(p => p.Product)
                   .ToArray().Select(p => new ProductViewModel()
                   {
                       Name = p.Name,
                       ImageUrl = p.ImageUrl,
                       Description = p.Description,
                       Quantity = x.OrderProducts
                        .Where(q => q.OrderId == x.Id)
                        .Select(q => q.Quantity)
                        .First(),
                       Size = p.Size,
                   })
                   .ToList(),

                Customer = new CustomerViewModel()
                {
                    UserId = x.Customer.UserId,
                    FirstName = x.Customer.FirstName,
                    LastName = x.Customer.LastName,
                    Town = x.Customer.TownName,
                    Address = x.Customer.Address,
                },
                Email = dbContext.Users.Where(u => u.Id == x.Customer.UserId).Select(x => x.Email).First(),
                Sum = x.Sum,
                CreatedOn = x.CreatedOn,
            }).ToArrayAsync();


            return customOrders;
        }
        public async Task MarkAnOrderAsDoneAsync(Guid orderId)
        {
            var order = await this.dbContext.Orders.FirstAsync(x => x.Id == orderId);
            order.IsDone = true;
            await dbContext.SaveChangesAsync();
        }

    }
}
