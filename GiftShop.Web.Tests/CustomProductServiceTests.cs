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
using GiftShop.Web.ViewModels.Customer;

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

            Assert.Equal(request[2].CustomProduct.Name, customProductViewModel.Name);
            Assert.Equal(request[2].CustomProduct.Description, customProductViewModel.Description);
            Assert.Equal(request[2].CustomProduct.Size, customProductViewModel.Size);
            Assert.Equal(request[2].CustomProduct.Quantity, customProductViewModel.Quantity);
            Assert.Equal(request[2].UserId, customProductViewModel.User);
        }

        [Fact]
        public async Task SeeIfGetAllRequestsGivesCorrectData()
        {
            var viewModelFirst = new CustomRequestViewModel()
            {
                RequestId = Guid.Parse("a0775228-4ae7-45ef-915b-a2befdd96bc8"),
                ProductId = Guid.Parse("3b40aa0e-6c86-4f13-ad33-bddd1a247201"),
                Name = "TestCustomProduct",
                Size = "10cm",
                Description = "Test Description",
                Quantity = 1,
            };
            var viewModelSecond = new CustomRequestViewModel()
            {
                RequestId = Guid.Parse("86ee833e-e048-422c-8040-e6fb21e9fcea"),
                ProductId = Guid.Parse("db42d48e-e0ad-4434-b195-394a13a8f227"),
                Name = "TestCustomProduct",
                Size = "10cm",
                Description = "Test Description",
                Quantity = 1,
            };
            var list = new List<CustomRequestViewModel> { viewModelFirst, viewModelSecond };
            var resultIenumerable = await this.customProductService.GetAllRequestsAsync();
            var result = resultIenumerable.ToList();

            Assert.Equal(list.Count, result.Count);

            Assert.Equal(list[0].RequestId, result[0].RequestId);
            Assert.Equal(list[0].ProductId, result[0].ProductId);
            Assert.Equal(list[0].Name, result[0].Name);
            Assert.Equal(list[0].Size, result[0].Size);
            Assert.Equal(list[0].Description, result[0].Description);
            Assert.Equal(list[0].Quantity, result[0].Quantity);

            Assert.Equal(list[1].RequestId, result[1].RequestId);
            Assert.Equal(list[1].ProductId, result[1].ProductId);
            Assert.Equal(list[1].Name, result[1].Name);
            Assert.Equal(list[1].Size, result[1].Size);
            Assert.Equal(list[1].Description, result[1].Description);
            Assert.Equal(list[1].Quantity, result[1].Quantity);

        }

        [Fact]
        public async Task SeeIfGetRequestByUserReturnsTheCorrectRequestWithoutCustomer()
        {
            var viewModel = new CustomRequestViewModel()
            {
                RequestId = Guid.Parse("a0775228-4ae7-45ef-915b-a2befdd96bc8"),
                ProductId = Guid.Parse("3b40aa0e-6c86-4f13-ad33-bddd1a247201"),
                Name = "TestCustomProduct",
                Size = "10cm",
                Description = "Test Description",
                Quantity = 1,
                ImageUrl = "TestUrl"

            };
            var model = await this.customProductService.GetRequestByUserAsync(Guid.Parse("a0775228-4ae7-45ef-915b-a2befdd96bc8"));

            Assert.Equal(viewModel.RequestId, model.RequestId);
            Assert.Equal(viewModel.ProductId, model.ProductId);
            Assert.Equal(viewModel.Name, model.Name);
            Assert.Equal(viewModel.Size, model.Size);
            Assert.Equal(viewModel.Description, model.Description);
            Assert.Equal(viewModel.Quantity, model.Quantity);
            Assert.Equal(viewModel.ImageUrl, model.ImageUrl);


        }
        [Fact]
        public async Task SeeIfGetRequestByUserReturnsTheCorrectRequestWithCustomer()
        {
            var viewModel = new CustomRequestViewModel()
            {
                RequestId = Guid.Parse("86ee833e-e048-422c-8040-e6fb21e9fcea"),
                ProductId = Guid.Parse("db42d48e-e0ad-4434-b195-394a13a8f227"),
                Name = "TestCustomProduct",
                Size = "10cm",
                Description = "Test Description",
                Quantity = 1,
                ImageUrl = "TestUrl",
                CustomerViewModel = new CustomerViewModel()
                {
                    FirstName = "CustomerFirstName",
                    LastName = "CustomerLastName",
                    Address = "TestAddress",
                    Town = "TestTown",
                }


            };
            var model = await this.customProductService.GetRequestByUserAsync(Guid.Parse("86ee833e-e048-422c-8040-e6fb21e9fcea"));

            Assert.Equal(viewModel.RequestId, model.RequestId);
            Assert.Equal(viewModel.ProductId, model.ProductId);
            Assert.Equal(viewModel.Name, model.Name);
            Assert.Equal(viewModel.Size, model.Size);
            Assert.Equal(viewModel.Description, model.Description);
            Assert.Equal(viewModel.Quantity, model.Quantity);
            Assert.Equal(viewModel.ImageUrl, model.ImageUrl);
            Assert.Equal(viewModel.CustomerViewModel.FirstName, model.CustomerViewModel.FirstName);
            Assert.Equal(viewModel.CustomerViewModel.LastName, model.CustomerViewModel.LastName);
            Assert.Equal(viewModel.CustomerViewModel.Town, model.CustomerViewModel.Town);
            Assert.Equal(viewModel.CustomerViewModel.Address, model.CustomerViewModel.Address);
        }

        [Fact]
        public async Task SeeIfGetRequestsFromUserReturnsCorrectRequest()
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
                CustomerViewModel = new CustomerViewModel()
                {
                    FirstName = "CustomerFirstName",
                    LastName = "CustomerLastName",
                    Address = "TestAddress",
                    Town = "TestTown",

                }
            };
            var model = await this.customProductService.GetRequestsFromUserAsync("testCustomerId");

            var result = model.ToList();

            Assert.Equal(viewModel.RequestId, result[0].RequestId);
            Assert.Equal(viewModel.ProductId, result[0].ProductId);
            Assert.Equal(viewModel.Name, result[0].Name);
            Assert.Equal(viewModel.Size, result[0].Size);
            Assert.Equal(viewModel.Description, result[0].Description);
            Assert.Equal(viewModel.Quantity, result[0].Quantity);
            Assert.Equal(viewModel.ImageUrl, result[0].ImageUrl);
            Assert.Equal(viewModel.CustomerViewModel.FirstName, result[0].CustomerViewModel.FirstName);
            Assert.Equal(viewModel.CustomerViewModel.LastName, result[0].CustomerViewModel.LastName);
            Assert.Equal(viewModel.CustomerViewModel.Town, result[0].CustomerViewModel.Town);
            Assert.Equal(viewModel.CustomerViewModel.Address, result[0].CustomerViewModel.Address);
        }

        [Fact]
        public async Task SeeIfDeleteRequestDeletesTheRequest()
        {
            await this.customProductService.DeleteRequestAsync(Guid.Parse("a0775228-4ae7-45ef-915b-a2befdd96bc8"), false);

            var request = this.dbContext.CustomRequests.FirstOrDefault(x => x.Id == Guid.Parse("a0775228-4ae7-45ef-915b-a2befdd96bc8"));
            var customProduct = this.dbContext.CustomProducts.FirstOrDefault(x => x.Id == Guid.Parse("3b40aa0e-6c86-4f13-ad33-bddd1a247201"));

            Assert.Null(request);
            Assert.Null(customProduct);

        }

        [Fact]
        public async Task SeeIfAcceptRequestAcceptsTheCorrectRequest()
        {
            var viewModel = new CustomRequestViewModel()
            {
                RequestId = Guid.Parse("a0775228-4ae7-45ef-915b-a2befdd96bc8"),
                ProductId = Guid.Parse("3b40aa0e-6c86-4f13-ad33-bddd1a247201"),
                Name = "TestCustomProduct",
                Size = "10cm",
                Description = "Test Description",
                Quantity = 1,
                ImageUrl = "TestUrl",
                Date= "10:10",
                Price = 10.00m
            };
            await this.customProductService.AcceptRequestAsync(viewModel, "test@gmail.com");
            var request = await this.dbContext.CustomRequests.FirstOrDefaultAsync(x => x.Id == viewModel.RequestId);
            Assert.Equal(request.Date, viewModel.Date);
            Assert.Equal(request.Price, viewModel.Price);
            Assert.Equal(request.IsAccepted, true);


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
            var customRequest = new CustomRequest()
            {
                UserId = user.Id,
                User = user,
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
            dbContext.CustomRequests.Add(customRequest);
            dbContext.CustomRequests.Add(customRequestWithUser);
            dbContext.SaveChanges();
        }



    }
}
