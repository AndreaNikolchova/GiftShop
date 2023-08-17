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

            var product = new Product()
            {
                Id = Guid.Parse("09a6440f-8dec-433f-aa73-577d9a017412"),
                Name = "test",
                Description = "test",
                ImageUrl = "tetsUrl",
                Price = 10m,
                Type = new ProductType()
                {
                    Id = Guid.Parse("52db6308-27d5-44e2-a796-3f4c470c8cde"),
                    Name = "Test"
                }
            };
           
            dbContext.Users.Add(user);
            dbContext.Users.Add(customerUser);
            dbContext.Customers.Add(customer);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
        }
    }
}
