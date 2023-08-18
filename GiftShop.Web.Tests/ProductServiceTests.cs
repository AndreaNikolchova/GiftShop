using GiftShop.Data;
using GiftShop.Services.CustomProducts.Contracts;
using GiftShop.Services.CustomProducts;
using GiftShop.Services.EmailSender.Contracts;
using GiftShop.Services.MediaService.Contracts;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using GiftShop.Services.Product.Contracts;
using GiftShop.Models;
using GiftShop.Services.Product;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Threading.Tasks;

namespace GiftShop.Web.Tests
{
    public class ProductServiceTests
    {
        private IProductService productService;
        private Mock<IMediaService> mediaServiceMock;

        private DbContextOptions<GiftShopDbContext> dbOptions;
        private GiftShopDbContext dbContext;
        public ProductServiceTests()
        {
           
            mediaServiceMock = new Mock<IMediaService>();
            this.dbOptions = new DbContextOptionsBuilder<GiftShopDbContext>()
                .UseInMemoryDatabase("GiftShopInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new GiftShopDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            productService = new ProductService(dbContext, mediaServiceMock.Object);
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


           
            dbContext.Users.Add(user);
            dbContext.Users.Add(customerUser);
            dbContext.Customers.Add(customer);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
        }
    }
}
