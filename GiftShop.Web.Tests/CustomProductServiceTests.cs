using GiftShop.Data;
using GiftShop.Models;
using GiftShop.Services.CustomProducts;
using GiftShop.Services.CustomProducts.Contracts;
using GiftShop.Services.EmailSender.Contracts;
using GiftShop.Services.MediaService.Contracts;
using GiftShop.Web.ViewModels.CustomProduct;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Moq;
using System.Threading.Tasks;
using Xunit;
using static GiftShop.Common.EmailMessagesConstants;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace GiftShop.Web.Tests
{
    public class CustomProductServiceTests
    {
        private ICustomProductService customProductService;
        private Mock<IMediaService> mediaServiceMock;
        private readonly Mock<IEmailSenderService> emailSenderServiceMock;

        private DbContextOptions<GiftShopDbContext> dbOptions;
        private GiftShopDbContext dbContext;
        public CustomProductServiceTests()
        {
            emailSenderServiceMock = new Mock<IEmailSenderService>();
            mediaServiceMock = new Mock<IMediaService>();
            this.dbOptions = new DbContextOptionsBuilder<GiftShopDbContext>()
                .UseInMemoryDatabase("CarMarketplaceInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new GiftShopDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            customProductService = new CustomProductService(dbContext, emailSenderServiceMock.Object, mediaServiceMock.Object);
        }
        [Fact]
        public async Task SeeIfAddCustomRequestAddsTheCorrectCustomRequest()
        {
            CustomProductViewModel customProductViewModel = new CustomProductViewModel()
            {
                Description = "Test description",
                Size = "10cm",
                Name = "Test",
                Quantity = 1,
                User = "testUserId",
                EmailAddress = "test@gmail.com",

            };

            await this.customProductService.AddCustomRequestAsync(customProductViewModel);

            var request = await dbContext.CustomRequests.ToListAsync();

            Assert.Equal(request[1].CustomProduct.Name, customProductViewModel.Name);
            Assert.Equal(request[1].CustomProduct.Description, customProductViewModel.Description);
            Assert.Equal(request[1].CustomProduct.Size, customProductViewModel.Size);
            Assert.Equal(request[1].CustomProduct.Quantity, customProductViewModel.Quantity);
            Assert.Equal(request[1].UserId, customProductViewModel.User);
        }

        [Fact]
        public async Task SeeIfGetAllRequestsGivesCorrectData()
        {
            var viewModel = new CustomRequestViewModel()
            {
                RequestId = Guid.Parse("a0775228-4ae7-45ef-915b-a2befdd96bc8"),
                ProductId = Guid.Parse("3b40aa0e-6c86-4f13-ad33-bddd1a247201"),
                Name = "TestCustomProduct",
                Size = "10cm",
                Description = "Test Description",
                Quantity = 1,
            };
           var list = new List<CustomRequestViewModel> { viewModel };
            var resultIenumerable = await this.customProductService.GetAllRequestsAsync();
            var result = resultIenumerable.ToList();

            Assert.Equal(list.Count, result.Count);
            Assert.Equal(list[0].RequestId, result[0].RequestId);
            Assert.Equal(list[0].ProductId, result[0].ProductId);
            Assert.Equal(list[0].Name, result[0].Name);
            Assert.Equal(list[0].Size, result[0].Size);
            Assert.Equal(list[0].Description, result[0].Description);
            Assert.Equal(list[0].Quantity, result[0].Quantity);
          
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
            var customRequest = new CustomRequest()
            {
                UserId = user.Id,
                Id = Guid.Parse("a0775228-4ae7-45ef-915b-a2befdd96bc8"),
                CustomProduct = new CustomProduct()
                {
                    Id = Guid.Parse("3b40aa0e-6c86-4f13-ad33-bddd1a247201"),
                    Name = "TestCustomProduct",
                    Size = "10cm",
                    Description = "Test Description",
                    Quantity = 1,
                    Price = 10.00m,
                    ImageId = "TestUrl"
                },
            };
            dbContext.CustomRequests.Add(customRequest);
            dbContext.SaveChanges();
        }



    }
}
