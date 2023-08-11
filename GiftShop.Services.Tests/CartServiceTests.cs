
namespace GiftShop.Services.Tests
{
    using GiftShop.Data;
    using GiftShop.Services.MediaService.Contracts;
    using GiftShop.Services.MediaService;
    using GiftShop.Services.Product;
    using GiftShop.Services.Product.Contracts;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System;
    using static DatabaseSeeder;
    using GiftShop.Services.Cart.Contracts;
    using GiftShop.Services.Cart;
    using GiftShop.Web.ViewModels.Cart;
    using System.Threading.Tasks;
    using GiftShop.Web.ViewModels.Product;
    using System.Collections.Generic;

    public class CartServiceTests
    {
        private DbContextOptions<GiftShopDbContext> dbOptions;
        private GiftShopDbContext dbContext;

        private ICartService cartService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<GiftShopDbContext>()
                .UseInMemoryDatabase("GiftShopInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new GiftShopDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.cartService = new CartService(this.dbContext);
        }
        [Test]
        public async Task GetCartInformationAsyncShouldReturnCorrectCartInformation()
        {
            var cart = await cartService.GetCartInformationAsync("3c63f6f4-4bae-45a1-8684-b0733c4907c3");
            CartViewModel cartView = new CartViewModel()
            {
                Products = new List<ProductViewModel>()
                {
                    new ProductViewModel()
                    {
                        Id = Guid.Parse("dd2c4893-8747-44c2-9471-885cb7b72df1"),
                        Name = "TestName",
                        Price = 1.00m.ToString(),
                        Description = "TestDescription",
                        Size = "10cm",
                        Quantity = 1
                    }
                },
                UserId = "3c63f6f4-4bae-45a1-8684-b0733c4907c3"
            };
            Assert.That(cartView, Is.EqualTo(cart));
        }
    }
}
