
namespace GiftShop.Web.Tests
{

using GiftShop.Data;
using GiftShop.Services.CustomProducts.Contracts;
using GiftShop.Services.CustomProducts;
using GiftShop.Services.EmailSender.Contracts;
using GiftShop.Services.MediaService.Contracts;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
    using GiftShop.Services.CustomOrder.Contracts;
    using GiftShop.Models;
    using Microsoft.AspNetCore.Identity;
    using GiftShop.Services.CustomOrder;
    using System.Threading.Tasks;
    using Xunit;
    using GiftShop.Web.ViewModels.Customer;
    using GiftShop.Web.ViewModels.CustomProduct;
    using System.Linq;

    public class CustomOrderServiceTests
    {
        private ICustomOrderService customOrderService;
        private Mock<ICustomProductService> customProductMock;
       
        private readonly Mock<IEmailSenderService> emailSenderServiceMock;

        private DbContextOptions<GiftShopDbContext> dbOptions;
        private GiftShopDbContext dbContext;
        public CustomOrderServiceTests()
        {
            emailSenderServiceMock = new Mock<IEmailSenderService>();
            customProductMock = new Mock<ICustomProductService>();
         
            this.dbOptions = new DbContextOptionsBuilder<GiftShopDbContext>()
                .UseInMemoryDatabase("GiftShopInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new GiftShopDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            customOrderService = new CustomOrderService(dbContext, emailSenderServiceMock.Object, customProductMock.Object);
        }

        [Fact]
        public async Task SeeIfAddCustomOrderAddsTheCorrectOrderWithUser()
        {
            var viewModel = new CustomRequestViewModel()
            {
                RequestId = Guid.Parse("86ee833e-e048-422c-8040-e6fb21e9fcea"),
                ProductId = Guid.Parse("db42d48e-e0ad-4434-b195-394a13a8f227"),
                Name = "TestCustomProduct",
                Size = "10cm",
                Description = "Test Description",
                Quantity = 1,
                Price = 10m,
                ImageUrl = "TestUrl",
                DeliveryCompany = 8.00m,
                Packaging = 0m,
                EmailAddress = "testcustomeremail@abv.bg",
                CustomerViewModel = new CustomerViewModel()
                {
                    FirstName = "CustomerFirstName",
                    LastName = "CustomerLastName",
                    Address = "TestAddress",
                    Town = "TestTown",

                }
            };
            await this.customOrderService.AddCustomOrderAsync(viewModel, "testcustomeremail@abv.bg");
            var order = this.dbContext.CustomOrders.First();

            Assert.Equal(order.Sum,10.00m);
            Assert.Equal(order.ProduductId ,viewModel.ProductId);
            Assert.Equal(order.Product.Name ,viewModel.Name);
            Assert.Equal(order.Product.Description ,viewModel.Description);
        }

     

        private void SeedDatabase(GiftShopDbContext dbContext)
        {
            var user = new IdentityUser()
            {
                Id = "testUserId",
                Email = "testemail@abv.bg",
                NormalizedEmail = "TESTEMAIL@ABV.BG",
                UserName = "testUser",
                NormalizedUserName = "TESTUSER",
                SecurityStamp = "12345",
                PasswordHash = "12345",
                ConcurrencyStamp = "12345",
                EmailConfirmed = false,
            };
            var customerUser = new IdentityUser()
            {
                Id = "testCustomerId",
                Email = "testcustomeremail@abv.bg",
                NormalizedEmail = "TESTCUSTOMEREMAIL@ABV.Bg",
                UserName = "testCustomer",
                NormalizedUserName = "TESTCUSTOMER",
                SecurityStamp = "12345",
                PasswordHash = "12345",
                ConcurrencyStamp = "12345",
                EmailConfirmed = false,
            };
            var customer = new Customer()
            {
                FirstName = "CustomerFirstName",
                LastName = "CustomerLastName",
                Address = "TestAddress",
                TownName = "TestTown",
                UserId = "testCustomerId",
                User = customerUser
            };
            var customRequestWithUser = new CustomRequest()
            {
                UserId = customerUser.Id,
                Id = Guid.Parse("86ee833e-e048-422c-8040-e6fb21e9fcea"),
                IsAccepted = true,
                CustomProduct = new CustomProduct()
                {
                    Id = Guid.Parse("db42d48e-e0ad-4434-b195-394a13a8f227"),
                    Name = "TestCustomProduct",
                    Size = "10cm",
                    Description = "Test Description",
                    Quantity = 1,
                    Price = 10.00m,
                    ImageId = "TestUrl"
                },
            };

            dbContext.Users.Add(user);
            dbContext.Users.Add(customerUser);
            dbContext.Customers.Add(customer);
            dbContext.CustomRequests.Add(customRequestWithUser);
            dbContext.SaveChanges();
        }
    }
}
