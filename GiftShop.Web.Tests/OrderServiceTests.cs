namespace GiftShop.Web.Tests
{ 
    using GiftShop.Data;
    using GiftShop.Models;
    using GiftShop.Services.EmailSender.Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using System;
    using GiftShop.Services.Order.Contracts;
    using GiftShop.Services.Order;
    using Xunit;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using GiftShop.Web.ViewModels.Customer;
    using GiftShop.Web.ViewModels.CustomProduct;
    using GiftShop.Web.ViewModels.Order;
    using GiftShop.Web.ViewModels.Product;
    using GiftShop.Web.ViewModels.Cart;

    public class OrderServiceTests
    {
        private IOrderService orderService;

        private readonly Mock<IEmailSenderService> emailSenderServiceMock;

        private DbContextOptions<GiftShopDbContext> dbOptions;
        private GiftShopDbContext dbContext;
        public OrderServiceTests()
        {
            emailSenderServiceMock = new Mock<IEmailSenderService>();

            this.dbOptions = new DbContextOptionsBuilder<GiftShopDbContext>()
                .UseInMemoryDatabase("GiftShopInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new GiftShopDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            orderService = new OrderService(dbContext, emailSenderServiceMock.Object);
        }

        [Fact]
        public async Task SeeIfAddOrderAddsTheCorrectOrder()
        {
            var cart = new CartViewModel()
            {
                UserId = "testUserId",
                Products = new List<ProductViewModel>()
                {
                    new ProductViewModel()
                    {
                        Id = Guid.Parse("7e53d7b9-ff1a-475c-8790-7f18d6c76dec"),
                        Price = "10",
                        Name = "Test",
                        Description = "Test",
                        Size= "10cm",
                        AllQuantity = 3,
                        Quantity=1,
                    }
                }
            };
            var orderViewModel = new OrderViewModel()
            {
                Cart = cart,
                Customer =  new CustomerViewModel()
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Address = "TestAddress",
                    Town = "TestTown",
                },
                DeliveryCompany = 8.00m,
                Packaging = 0m,
                Sum  = 10m
            };

            await this.orderService.AddOrder(orderViewModel, "testUserId", "testemail@abv.bg");

            var order = this.dbContext.Orders.ToList()[1];
            Assert.Equal(order.Sum, 10m);
            Assert.Equal(order.Customer.UserId, "testUserId");
            Assert.Equal(order.OrderProducts.First().ProductId, Guid.Parse("7e53d7b9-ff1a-475c-8790-7f18d6c76dec"));
           
        }

        [Fact]
        public async Task SeeIfAddOrderAddsTheCorrectOrderWithExistingCustomer()
        {
            var cart = new CartViewModel()
            {
                UserId = "testCustomerId",
                Products = new List<ProductViewModel>()
                {
                    new ProductViewModel()
                    {
                        Id = Guid.Parse("7e53d7b9-ff1a-475c-8790-7f18d6c76dec"),
                        Price = "10",
                        Name = "Test",
                        Description = "Test",
                        Size= "10cm",
                        AllQuantity = 3,
                        Quantity=1,
                    }
                }
            };
            var orderViewModel = new OrderViewModel()
            {
                Cart = cart,
                Customer = new CustomerViewModel()
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Address = "TestAddress",
                    Town = "TestTown",
                },
                DeliveryCompany = 8.00m,
                Packaging = 0m,
                Sum = 10m
            };

            await this.orderService.AddOrder(orderViewModel, "testCustomerId", "testCustomerEmail@abv.bg");

            var order = this.dbContext.Orders.ToList()[1];
            Assert.Equal(order.Sum, 10m);
            Assert.Equal(order.Customer.UserId, "testCustomerId");
            Assert.Equal(order.OrderProducts.First().ProductId, Guid.Parse("7e53d7b9-ff1a-475c-8790-7f18d6c76dec"));

        }


        [Fact]
        public async Task SeeIfFillOrderViewModelReturnsCorrectModel()
        {
            var model = new CartViewModel()
            {
                UserId = "testCustomerId",
                Products = new List<ProductViewModel>()
                {
                    new ProductViewModel()
                    {
                        Id = Guid.Parse("7e53d7b9-ff1a-475c-8790-7f18d6c76dec"),
                        Price = "10",
                        Name = "Test",
                        Description = "Test",
                        Size= "10cm",
                        AllQuantity = 3,
                        Quantity=1,
                    }
                }
            };
            var result = await this.orderService.FillOrderViewModel(model);
            Assert.Equal(result.Sum, 10m);
            Assert.Equal(result.Customer.FirstName, "CustomerFirstName");
            Assert.Equal(result.Cart, model);
        }


        [Fact]
        public async Task SeeIfGetAllOrdersReturnCorrectInformation()
        {
            var model = new OrderViewModel()
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
                Products =  new List<ProductViewModel>(),

            };
            var models = await this.orderService.GetAllOrdersAsync();
            var result = models.ToList()[0];

            Assert.Equal(model.Id, result.Id);
            Assert.Equal(model.Sum, result.Sum);

            Assert.Equal(model.Customer.Address, result.Customer.Address);
            Assert.Equal(model.Customer.FirstName, result.Customer.FirstName);
            Assert.Equal(model.Customer.LastName, result.Customer.LastName);
            Assert.Equal(model.Customer.Town, result.Customer.Town);


        }


        [Fact]
        public async Task SeeIfMarkAnOrderAsDoneMarksTheCorrectOrder()
        {

            await this.orderService.MarkAnOrderAsDoneAsync(Guid.Parse("e92d29c4-15af-4b6d-8bb8-e75a8e54f98c"));
            var order = dbContext.Orders.First(x => x.Id == Guid.Parse("e92d29c4-15af-4b6d-8bb8-e75a8e54f98c"));

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

            var product = new Product()
            {

                Id = Guid.Parse("7e53d7b9-ff1a-475c-8790-7f18d6c76dec"),
                Price = 10m,
                Name = "Test",
                Description = "Test",
                Size = "10cm",
                Quantity = 5,
                ImageUrl = "testUrl"
            };
            var cartUserOne = new Cart()
            {
                UserId = "testUserId"
            }; 
            var cartUserTwo = new Cart()
            {
                UserId = "testCustomerId"
            };
            var order = new Order()
            {
                Id= Guid.Parse("e92d29c4-15af-4b6d-8bb8-e75a8e54f98c"),
                Customer =  customer,
                Sum = 10m,
                OrderProducts = new List<OrderProduct>() 
            };

            dbContext.Users.Add(user);
            dbContext.Users.Add(customerUser);
            dbContext.Cart.Add(cartUserOne);
            dbContext.Cart.Add(cartUserTwo);
            dbContext.Products.Add(product);
            dbContext.Orders.Add(order);
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
        }
    }
}
