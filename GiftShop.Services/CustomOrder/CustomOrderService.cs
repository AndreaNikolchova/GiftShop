namespace GiftShop.Services.CustomOrder
{
    using GiftShop.Data;
    using GiftShop.Models;
    using GiftShop.Services.CustomOrder.Contracts;
    using GiftShop.Services.CustomProducts.Contracts;
    using GiftShop.Services.EmailSender.Contracts;
    using GiftShop.Web.ViewModels.Customer;
    using GiftShop.Web.ViewModels.CustomProduct;
    using GiftShop.Web.ViewModels.DeliveryCompany;
    using GiftShop.Web.ViewModels.Order;
    using GiftShop.Web.ViewModels.Packaging;
    using Microsoft.EntityFrameworkCore;
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
            if (!await customProductService.SeeIfUserIsACustomerAsync(request.EmailAddress))
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
            else
            {
                customer = await dbContext.Customers.FirstOrDefaultAsync(x => x.User.Email == request.EmailAddress);
                if (customer.Address != request.CustomerViewModel.Address)
                {
                    customer.Address = request.CustomerViewModel.Address;
                }
            }
            CustomOrder customOrder = new CustomOrder()
            {
                Customer = customer,
                ProduductId = request.ProductId,
                DeliveryCompanyId = dbContext.DeliveryCompanies
                .Where(x => x.Name == request.CustomerViewModel.DeliveryCompanyName)
                .Select(x => x.Id)
                .First(),

            };
            dbContext.CustomOrders.Add(customOrder);
            dbContext.CustomRequests.Remove(dbContext.CustomRequests.FirstOrDefault(x => x.Id == request.RequestId)!);
            await dbContext.SaveChangesAsync();
            emailSender.SendEmail(email, RecievedCustomOrderSubject, RecievedCustomOrderBody, Ending);

        }
        public async Task<IEnumerable<CustomOrderViewModel>> GetAllOrdersAsync()
        {
            var customOrders = this.dbContext.CustomOrders.Select(x => new CustomOrderViewModel()
            {
                Id = x.Id,
                Customer = new CustomerViewModel()
                {
                    UserId = x.Customer.UserId,
                    FirstName= x.Customer.FirstName,
                    LastName= x.Customer.LastName,
                    Town = x.Customer.TownName,
                    Address = x.Customer.Address,
                },
                DeliveryCompany= new DeliveryCompanyViewModel()
                {
                    Id=x.DeliveryCompany.Id,
                    Name=x.DeliveryCompany.Name,
                },
                Packaging = new PackagingViewModel()
                {
                    Id = .Id,
                    Name = x.DeliveryCompany.Name,
                }

            });

        }
    }
}
