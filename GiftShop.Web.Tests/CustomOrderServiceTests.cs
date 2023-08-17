namespace GiftShop.Web.Tests
{

    using GiftShop.Data;
    using GiftShop.Services.CustomProducts.Contracts;

    using GiftShop.Services.EmailSender.Contracts;

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
    using GiftShop.Web.ViewModels.Order;
    

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
        public async Task SeeIfAddCustomOrderAddsTheCorrectOrder()
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
                EmailAddress = "testemail@abv.bg",
                CustomerViewModel = new CustomerViewModel()
                {
                    Address = "testAddress",
                    FirstName = "test",
                    LastName = "test",
                    Town = "testTown"
                }

            };
            await this.customOrderService.AddCustomOrderAsync(viewModel, "testemail@abv.bg");
            var order = this.dbContext.CustomOrders.ToList()[1];

            Assert.Equal(order.Sum, 10.00m);
            Assert.Equal(order.ProduductId, viewModel.ProductId);
            Assert.Equal(order.Product.Name, viewModel.Name);
            Assert.Equal(order.Product.Description, viewModel.Description);
        }

        [Fact]
        public async Task SeeIfGetAllOrdersReturnCorrectInformation()
        {
            var model = new CustomOrderViewModel()
            {
                Id = Guid.Parse("e92d29c4-15af-4b6d-8bb8-e75a8e54f98c"),
                Customer = new CustomerViewModel()
                {
                    FirstName = "CustomerFirstName",
                    LastName = "CustomerLastName",
                    Address = "TestAddress",
                    Town = "TestTown",
                },
                Sum = 10.00m,
                CreatedOn = DateTime.Now,
                Product = new CustomProductViewModel()
                {
                    Description = "Test",
                    Size = "10cm",
                    Name = "test",
                    Quantity = 1,
                    EmailAddress = "testCustomerEmail@abv.bg"
                }
            };
            var models = await this.customOrderService.GetAllOrdersAsync();
            var result = models.ToList()[0];

            Assert.Equal(model.Id, result.Id);
            Assert.Equal(model.Sum, result.Sum);

            Assert.Equal(model.Customer.Address, result.Customer.Address);
            Assert.Equal(model.Customer.FirstName, result.Customer.FirstName);
            Assert.Equal(model.Customer.LastName, result.Customer.LastName);
            Assert.Equal(model.Customer.Town, result.Customer.Town);

            Assert.Equal(model.Product.Name, result.Product.Name);
            Assert.Equal(model.Product.Description, result.Product.Description);
            Assert.Equal(model.Product.Size, result.Product.Size);
            Assert.Equal(model.Product.Quantity, result.Product.Quantity);

        }

        [Fact]
        public async Task SeeIfMarkAnOrderAsDoneMarksTheCorrectOrder()
        {

            await this.customOrderService.MarkAnOrderAsDoneAsync(Guid.Parse("e92d29c4-15af-4b6d-8bb8-e75a8e54f98c"));
            var order = dbContext.CustomOrders.First(x => x.Id == Guid.Parse("e92d29c4-15af-4b6d-8bb8-e75a8e54f98c"));

            Assert.True(order.IsDone);

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
                Email = "testCustomerEmail@abv.bg",
                NormalizedEmail = "TESTCUSTOMEREMAIL@ABV.BG",
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
                User = customerUser
            };

            var customOrder = new CustomOrder()
            {
                Id = Guid.Parse("e92d29c4-15af-4b6d-8bb8-e75a8e54f98c"),
                Customer = customer,
                Sum = 10.00m,
                CreatedOn = DateTime.Now,
                Product = new CustomProduct()
                {
                    Id = Guid.Parse("263f96ed-fb10-4829-b933-9743afbca672"),
                    Description = "Test",
                    Name = "test",
                    Size = "10cm",
                    Quantity = 1,
                }
            };

            dbContext.Users.Add(user);
            dbContext.Users.Add(customerUser);
            dbContext.CustomOrders.Add(customOrder);
            dbContext.Customers.Add(customer);
            dbContext.CustomRequests.Add(customRequestWithUser);
            dbContext.SaveChanges();
        }
    }
}
