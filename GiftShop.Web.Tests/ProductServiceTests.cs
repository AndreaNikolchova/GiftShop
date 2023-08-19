using GiftShop.Data;
using GiftShop.Services.MediaService.Contracts;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using GiftShop.Services.Product.Contracts;
using GiftShop.Models;
using GiftShop.Services.Product;
using Microsoft.AspNetCore.Identity;

using Xunit;
using System.Threading.Tasks;
using GiftShop.Web.ViewModels.Product;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [Fact]
        public async Task SeeIfGetLast3ProductsReturnsCorrectInformation()
        {
            var model = new ProductViewModel()
            {
                Name = "Blanket",
                Description = "Wrap yourself in the soothing comfort of our blue soft crochet blanket. Handcrafted with care, this cozy and inviting blanket features a delicate crochet pattern that adds a touch of elegance to its comforting embrace. ",
                ImageUrl = "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg",
                Price = "130.00",
                Type = "Accessories"
            };

            var list = await this.productService.GetLast3ProductsAsync();
            var result = list.ToList()[0];

            Assert.Equal(model.Name, result.Name);
            Assert.Equal(model.Description, result.Description);
            Assert.Equal(model.ImageUrl, result.ImageUrl);
            Assert.Equal(model.Price, result.Price);
            Assert.Equal(model.Type, result.Type);

        }

        [Fact]
        public async Task SeeIfGetAllReturnsCorrectCount()
        {
            var list = await this.productService.GetAllAsync("Toys");

            Assert.Equal(list.Count(), 3);

        }

        [Fact]
        public async Task SeeIfGetDetailsReturnsCorrectInformation()
        {
            var model = new ProductDetailsViewModel()
            {
                Id = Guid.Parse("c818e057-eb7d-4163-8ad1-04c7274abb40"),
                Name = "Test",
                Description = "Test",
                Price = "10",
                ImageUrl = "TestUrl",
                Size = "10cm",
                Type = "Test",
                YarnName = "TestYarn"

            };

            var result = await this.productService.GetDetailsAsync(Guid.Parse("c818e057-eb7d-4163-8ad1-04c7274abb40"));

            Assert.Equal(model.Id, result.Id);
            Assert.Equal(model.Name, result.Name);
            Assert.Equal(model.Description, result.Description);
            Assert.Equal(model.Price, result.Price);
            Assert.Equal(model.ImageUrl, result.ImageUrl);
            Assert.Equal(model.YarnName, result.YarnName);
            Assert.Equal(model.Type, result.Type);


        }

        [Fact]
        public async Task SeeIfFillTypesWorks()
        {
            var result = await this.productService.FillTypesAsync();

            Assert.Equal(result.Types.Count(), 5);
        }

        [Fact]
        public async Task SeeIfDeleteWorks()
        {
            await this.productService.DeleteAsync(Guid.Parse("c818e057-eb7d-4163-8ad1-04c7274abb40"));
            var product = await this.dbContext.Products.FirstOrDefaultAsync(x => x.Id == Guid.Parse("c818e057-eb7d-4163-8ad1-04c7274abb40"));

            Assert.Null(product);
        }

        [Fact]
        public async Task SeeIfGetDetailsForEditReturnsCorrectInformation()
        {
            var model = new EditProductViewModel()
            {
                Id = Guid.Parse("c818e057-eb7d-4163-8ad1-04c7274abb40"),
                Name = "Test",
                Description = "Test",
                Price = "10",
                ImageUrl = "TestUrl",
                Size = "10cm",
                Type = "Test",
                YarnType = "TestYarn"

            };

            var result = await this.productService.GetDetailsForEditAsync(Guid.Parse("c818e057-eb7d-4163-8ad1-04c7274abb40"));

            Assert.Equal(model.Id, result.Id);
            Assert.Equal(model.Name, result.Name);
            Assert.Equal(model.Description, result.Description);
            Assert.Equal(model.Price, result.Price);
            Assert.Equal(model.ImageUrl, result.ImageUrl);
            Assert.Equal(model.YarnType, result.YarnType);
            Assert.Equal(model.Type, result.Type);


        }

        [Fact]
        public async Task SeeIfAddProductAddsTheCorrectProduct()
        {
            var filePath = @"C:\Users\Adi\Desktop\photos for giftshop\IMG_3876.jpeg";
            var fileName = Path.GetFileName(filePath);

            var formFile = new FormFile(
                baseStream: new FileStream(filePath, FileMode.Open, FileAccess.Read),
                baseStreamOffset: 0,
                length: new FileInfo(filePath).Length,
                name: "Photo",
                fileName: fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };



            var model = new AddProductViewModel()
            {

                Name = "TestAdd",
                Description = "TestAdd",
                Price = "10",
                Photo = formFile,
                Size = "10cm",
                Type = "Test",
                YarnType = "TestYarn"

            };

            await this.productService.AddProductAsync(model);

            var product = this.dbContext.Products.FirstOrDefault(x => x.Name == "TestAdd");

            Assert.NotNull(product);
        }

        [Fact]
        public async Task SeeIfAddProductAddsTheCorrectProductWithNewYarn()
        {
            var filePath = @"C:\Users\Adi\Desktop\photos for giftshop\IMG_3876.jpeg";
            var fileName = Path.GetFileName(filePath);

            var formFile = new FormFile(
                baseStream: new FileStream(filePath, FileMode.Open, FileAccess.Read),
                baseStreamOffset: 0,
                length: new FileInfo(filePath).Length,
                name: "Photo",
                fileName: fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };



            var model = new AddProductViewModel()
            {

                Name = "TestAdd",
                Description = "TestAdd",
                Price = "10",
                Photo = formFile,
                Size = "10cm",
                Type = "Test",
                YarnType = "new"

            };

            await this.productService.AddProductAsync(model);

            var product = this.dbContext.Products.FirstOrDefault(x => x.Name == "TestAdd");

            Assert.NotNull(product);
        }

        [Fact]
        public async Task SeeIfUpdateProductWorksWithANewPhoto()
        {
            var filePath = @"C:\Users\Adi\Desktop\photos for giftshop\IMG_3876.jpeg";
            var fileName = Path.GetFileName(filePath);

            var formFile = new FormFile(
                baseStream: new FileStream(filePath, FileMode.Open, FileAccess.Read),
                baseStreamOffset: 0,
                length: new FileInfo(filePath).Length,
                name: "Photo",
                fileName: fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };



            var model = new EditProductViewModel()
            {
                Id = Guid.Parse("c818e057-eb7d-4163-8ad1-04c7274abb40"),
                Name = "Test",
                Description = "Test",
                Price = "10",
                Photo = formFile,
                Size = "10cm",
                Type = "Test",
                YarnType = "TestYarn",
                Quantity= 5

            };

            await this.productService.UpdateProductInformation(model);

            var result = this.dbContext.Products.FirstOrDefault(x => x.Name == "Test");
            Assert.Equal(model.Id, result.Id);
            Assert.Equal(model.Name, result.Name);
            Assert.Equal(model.Description, result.Description);
            Assert.Equal(model.Price, result.Price.ToString());
            Assert.Equal(model.ImageUrl, result.ImageUrl);
            Assert.Equal(model.YarnType, result.YarnType.Name);
            Assert.Equal(model.Type, result.Type.Name);



        }
        [Fact]
        public async Task SeeIfUpdateProductWorksWithNewProductTypeAndYarnType()
        {
            
            var model = new EditProductViewModel()
            {
                Id = Guid.Parse("c818e057-eb7d-4163-8ad1-04c7274abb40"),
                Name = "Test",
                Description = "Test",
                Price = "10",
                ImageUrl = "testUrl",
                Size = "10cm",
                Type = "new",
                YarnType = "new",
                Quantity = 5

            };

            await this.productService.UpdateProductInformation(model);

            var result = this.dbContext.Products.FirstOrDefault(x => x.Name == "Test");
            Assert.Equal(model.Id, result.Id);
            Assert.Equal(model.Name, result.Name);
            Assert.Equal(model.Description, result.Description);
            Assert.Equal(model.Price, result.Price.ToString());
            Assert.Equal(model.YarnType, result.YarnType.Name);
            Assert.Equal(model.Type, result.Type.Name);
        }

        [Fact]
        public async Task SeeIfAddToCartWorksWithNewCart()
        {
          await this.productService.AddToCartAsync(Guid.Parse("c818e057-eb7d-4163-8ad1-04c7274abb40"), "testUserId");
            Assert.NotNull(this.dbContext.Cart.FirstOrDefault(x => x.UserId == "testUserId"));
            Assert.Equal(this.dbContext.Cart.FirstOrDefault(x => x.UserId == "testUserId").CartProduct.Count,1);

        }

        [Fact]
        public async Task SeeIfAddToCartWorksWithAlreadyMadeCart()
        {
            await this.productService.AddToCartAsync(Guid.Parse("c818e057-eb7d-4163-8ad1-04c7274abb40"), "testCustomerId");
            Assert.NotNull(this.dbContext.Cart.FirstOrDefault(x => x.UserId == "testCustomerId"));
            Assert.Equal(this.dbContext.Cart.FirstOrDefault(x => x.UserId == "testCustomerId").CartProduct.Count, 1);

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
                Id = Guid.Parse("c818e057-eb7d-4163-8ad1-04c7274abb40"),
                Name = "Test",
                Description = "Test",
                Price = 10m,
                ImageUrl = "TestUrl",
                Size = "10cm",
                Type = new ProductType()
                {
                    Name = "Test",
                },
                YarnType = new YarnType()
                {
                    Name = "TestYarn"
                }
            };
            var newType= new ProductType()
            {
                Name = "new",
            };
             var newYarn = new YarnType()
            {
                Name = "new"
            };

            var cart = new Cart()
            {
                UserId = "testCustomerId",
                CartProduct = new List<CartProduct>()
            };

            dbContext.Users.Add(user);
            dbContext.Users.Add(customerUser);
            dbContext.Customers.Add(customer);
            dbContext.Cart.Add(cart);
            dbContext.Products.Add(product);
            dbContext.ProductTypes.Add(newType);
            dbContext.YarnTypes.Add(newYarn);
            dbContext.SaveChanges();
        }
    }
}