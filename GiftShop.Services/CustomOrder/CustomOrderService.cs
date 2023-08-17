namespace GiftShop.Services.CustomOrder
{
    using Microsoft.EntityFrameworkCore;

    using GiftShop.Data;
    using GiftShop.Models;
    using GiftShop.Services.CustomOrder.Contracts;
    using GiftShop.Services.CustomProducts.Contracts;
    using GiftShop.Services.EmailSender.Contracts;
    using GiftShop.Web.ViewModels.Customer;
    using GiftShop.Web.ViewModels.CustomProduct;
    using GiftShop.Web.ViewModels.Order;
    using static GiftShop.Common.EmailMessagesConstants;

    public class CustomOrderService : ICustomOrderService
    {
        public GiftShopDbContext dbContext { get; set; }
        private IEmailSenderService emailSender;
        private ICustomProductService customProductService;

        public CustomOrderService(GiftShopDbContext dbContext, IEmailSenderService emailSender, ICustomProductService customProductService)
        {
            this.dbContext = dbContext;
            this.emailSender = emailSender;
            this.customProductService = customProductService;
        }

        public async Task AddCustomOrderAsync(CustomRequestViewModel request, string email)
        {
            var customer = new Customer();
            var test = await customProductService.SeeIfUserIsACustomerAsync(request.EmailAddress);
            if (await customProductService.SeeIfUserIsACustomerAsync(request.EmailAddress))
            {

                customer = await dbContext.Customers.FirstOrDefaultAsync(x => x.User.Email == request.EmailAddress);
                if (customer.Address != request.CustomerViewModel.Address)
                {
                    customer.Address = request.CustomerViewModel.Address;
                }
                if (customer.TownName != request.CustomerViewModel.Town)
                {
                    customer.TownName = request.CustomerViewModel.Town;
                }
                

            }
            else
            {
                customer.FirstName = request.CustomerViewModel.FirstName;
                customer.LastName = request.CustomerViewModel.LastName;
                customer.Address = request.CustomerViewModel.Address;
                customer.TownName = request.CustomerViewModel.Town;
                customer.User = dbContext.Users
                .Where(x => x.Email == request.EmailAddress)
                .First();
                dbContext.Customers.Add(customer);
            }
            var deliveryCompanyId =  await dbContext.DeliveryCompanies
                .Where(x => x.Price == request.DeliveryCompany)
                .Select(x => x.Id)
                .FirstAsync();
            var packagingId =  await dbContext.Packaging
                .Where(x => x.Price == request.Packaging)
                .Select(x => x.Id)
                .FirstAsync();
            CustomOrder customOrder = new CustomOrder()
            {
                Customer = customer,
                ProduductId = request.ProductId,
                DeliveryCompanyId = deliveryCompanyId,
                CreatedOn= DateTime.Now,
                PackagingId = packagingId,
                Sum = request.Price,

            };
            dbContext.CustomOrders.Add(customOrder);
            dbContext.CustomRequests.Remove(dbContext.CustomRequests.FirstOrDefault(x => x.Id == request.RequestId)!);
            await dbContext.SaveChangesAsync();
            emailSender.SendEmail(email, RecievedCustomOrderSubject, RecievedCustomOrderBody, Ending);

        }
        public async Task<IEnumerable<CustomOrderViewModel>> GetAllOrdersAsync()
        {
            var customOrders = await this.dbContext.CustomOrders.Where(x=>x.IsDone == false).OrderBy(x=>x.CreatedOn).Select(x => new CustomOrderViewModel()
            {
                Id = x.Id,
                Customer = new CustomerViewModel()
                {
                    UserId = x.Customer.UserId,
                    FirstName = x.Customer.FirstName,
                    LastName = x.Customer.LastName,
                    Town = x.Customer.TownName,
                    Address = x.Customer.Address,
                },
                Sum = x.Sum,
                CreatedOn = x.CreatedOn,
                Product = new CustomProductViewModel()
                {
                    Name = x.Product.Name,
                    Description = x.Product.Description,
                    ImageUrl = x.Product.ImageId,
                    Size = x.Product.Size,
                    Quantity = x.Product.Quantity,
                    EmailAddress = dbContext.Users.Where(u=>u.Id == x.Customer.UserId).Select(x=>x.Email).First(),

                }
            }).ToArrayAsync();


            return customOrders;
        }
        public async Task MarkAnOrderAsDoneAsync(Guid orderId)
        {
            var order = await this.dbContext.CustomOrders.FirstAsync(x => x.Id == orderId);
            order.IsDone = true;
            await dbContext.SaveChangesAsync();
        }
       
    }
}
