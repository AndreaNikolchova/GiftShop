
namespace GiftShop.Web.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using GiftShop.Data;
    using GiftShop.Models;
    using GiftShop.Services.Cart;
    using GiftShop.Services.Cart.Contracts;
    using GiftShop.Web.ViewModels.Cart;
    using GiftShop.Web.ViewModels.Product;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CartServiceTests
    {
        private ICartService cartsService;
        private DbContextOptions<GiftShopDbContext> dbOptions;
        private GiftShopDbContext dbContext;
        public CartServiceTests()
        {
            this.dbOptions = new DbContextOptionsBuilder<GiftShopDbContext>()
                .UseInMemoryDatabase("CarMarketplaceInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new GiftShopDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.cartsService = new CartService(this.dbContext);
        }


        [Fact]
        public async Task SeeIfGetCartInformationAsyncReturnsCorrectInformation()
        {
            var model = await this.cartsService.GetCartInformationAsync("testUserId");
            var productViewModel = new ProductViewModel()
            {
                Id = Guid.Parse("a7adbf84-330a-4411-8fd7-2f8258793f63"),
                Name = "Test",
                ImageUrl = "testUrl",
                Price = 10.99.ToString(),
                Description = "Test description",
                Size = "10cm",
                Type = "Test type",
                AllQuantity = 5,
            };
            var listProducts = new List<ProductViewModel>() { productViewModel };
            var cartViewModel = new CartViewModel()
            {
                UserId = "testUserId",
                Products = listProducts
            };
            Assert.Equal(cartViewModel.UserId, model.UserId);
            Assert.Equal(cartViewModel.Products.Count, model.Products.Count);
            Assert.Equal(cartViewModel.Products[0].Id, model.Products[0].Id);
            Assert.Equal(cartViewModel.Products[0].Name, model.Products[0].Name);
            Assert.Equal(cartViewModel.Products[0].ImageUrl, model.Products[0].ImageUrl);
            Assert.Equal(cartViewModel.Products[0].Price, model.Products[0].Price);
            Assert.Equal(cartViewModel.Products[0].Description, model.Products[0].Description);
            Assert.Equal(cartViewModel.Products[0].Size, model.Products[0].Size);
            Assert.Equal(cartViewModel.Products[0].Type, model.Products[0].Type);
            Assert.Equal(cartViewModel.Products[0].AllQuantity, model.Products[0].AllQuantity);

        }
        [Fact]
        public async Task SeeIfGetCartInformationAsyncReturnsNewCartModel()
        {
            var model = await this.cartsService.GetCartInformationAsync("UserWithOutCart");
            var cartViewModel = new CartViewModel()
            {
                UserId = null,
                Products = new List<ProductViewModel>()
            };
            Assert.Equal(cartViewModel.UserId, model.UserId);
            Assert.Equal(cartViewModel.Products.Count, model.Products.Count);
            Assert.Equal(cartViewModel.Products, model.Products);

        }

        [Fact]
        public async Task SeeIfRemoveProductFromCartRemovesTheCorrectProduct()
        {
            var productId = Guid.Parse("a7adbf84-330a-4411-8fd7-2f8258793f63");
            await this.cartsService.RemoveProductFromCart("testUserId", productId);
          
            var cart = this.dbContext.Cart.Where(x => x.UserId == "testUserId").FirstOrDefault();
            Assert.Equal(this.dbContext.Cart.Where(x => x.UserId == "testUserId").FirstOrDefault().CartProduct.Count, 0);       
            Assert.Null(this.dbContext.CartProducts.Where(x=>x.ProductId == Guid.Parse("a7adbf84-330a-4411-8fd7-2f8258793f63")&& x.CartId == Guid.Parse("7907f5c4-9759-48f3-815b-d187efbd18ee")).FirstOrDefault());
          

        }
        private void SeedDatabase(GiftShopDbContext dbContext)
        {
            var user = new IdentityUser()
            {
                Id = "testUserId",
                Email = "testemail@abv.bg",
                NormalizedEmail = "TESTEMAIL@ABV.Bg",
                UserName = "testUser",
                NormalizedUserName = "TESTUSER",
                SecurityStamp = "12345",
                PasswordHash = "12345",
                ConcurrencyStamp = "12345",
                EmailConfirmed = false,
            };
            dbContext.Users.Add(user);
            var cart = new Cart()
            {
                Id= Guid.Parse("7907f5c4-9759-48f3-815b-d187efbd18ee"),
                UserId = "testUserId"
            };
            var product = new Product()
            {
                Id = Guid.Parse("a7adbf84-330a-4411-8fd7-2f8258793f63"),
                ImageUrl = "testUrl",
                Price = 10.99m,
                Name = "Test",
                Description = "Test description",
                Quantity = 5,
                Size = "10cm",
                Type = new ProductType() { Name = "Test type" },
                YarnType = new YarnType() { Name = "Test yarn type" }
            };
            var cartProduct = new CartProduct()
            {
                Cart = cart,
                Product = product,
            };
            List<CartProduct> cartProducts = new List<CartProduct>() { cartProduct };

            product.CartProduct = cartProducts;
            cart.CartProduct = cartProducts;
            dbContext.CartProducts.Add(cartProduct);
            dbContext.Products.Add(product);
            dbContext.Cart.Add(cart);
            dbContext.SaveChanges();
        }
    }
}