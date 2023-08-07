namespace GiftShop.Services.CustomProducts
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using GiftShop.Data;
    using GiftShop.Models;
    using GiftShop.Services.EmailSender.Contracts;
    using GiftShop.Services.MediaService.Contracts;
    using GiftShop.Services.CustomProducts.Contracts;
    using GiftShop.Web.ViewModels.CustomProduct;
    using GiftShop.Web.ViewModels.Customer;
    using static GiftShop.Common.EmailMessagesConstants;


    public class CustomProductService : ICustomProductService
    {
        public GiftShopDbContext dbContext { get; set; }
        private IEmailSenderService emailSender;
        private IMediaService mediaService;

        public CustomProductService(GiftShopDbContext dbContext, IEmailSenderService emailSender, IMediaService mediaService)
        {
            this.dbContext = dbContext;
            this.emailSender = emailSender;
            this.mediaService = mediaService;
        }

        public async Task AddCustomRequestAsync(CustomProductViewModel product)
        {
            CustomProduct customProduct = new CustomProduct()
            {
                Description = product.Description,
                Size = product.Size,
                Name = product.Name,
                Quantity = product.Quantity,
            };
            if (product.Photo != null)
            {
                var picture = await this.mediaService.UploadPictureAsync(product.Photo, product.Name);
                customProduct.ImageId = picture;
            }
            await dbContext.AddAsync<CustomProduct>(customProduct);
            CustomRequest request = new CustomRequest()
            {
                CustomProduct = customProduct,
                UserId = product.User!,
                IsAccepted = false
            };
            await dbContext.AddAsync<CustomRequest>(request);
            await dbContext.SaveChangesAsync();
            emailSender.SendEmail(product.EmailAddress, CustomOrderSubject, CustomOrderBody, CustomOrderEnding);


        }


        public async Task<IEnumerable<CustomRequestViewModel>> GetAllRequestsAsync()
        {
            var customRequests = await dbContext.CustomRequests
                .Where(x => x.IsAccepted == false)
                .Select(x => new CustomRequestViewModel()
                {
                    RequestId = x.Id,
                    ProductId = x.CustomProductId,
                    Name = x.CustomProduct.Name,
                    ImageUrl = x.CustomProduct.ImageId,
                    Description = x.CustomProduct.Description,
                    Size = x.CustomProduct.Size,
                    Quantity = x.CustomProduct.Quantity,
                    EmailAddress = x.User.Email,

                }).ToArrayAsync();
            return customRequests;
        }

        public async Task<CustomRequestViewModel> GetRequestByUserAsync(Guid id)
        {
            var customRequest = await dbContext.CustomRequests
                .Where(x => x.Id == id)
                .Select(x => new CustomRequestViewModel()
                {
                    RequestId = x.Id,
                    ProductId = x.CustomProductId,
                    Name = x.CustomProduct.Name,
                    ImageUrl = x.CustomProduct.ImageId,
                    Description = x.CustomProduct.Description,
                    Size = x.CustomProduct.Size,
                    Quantity = x.CustomProduct.Quantity,
                    EmailAddress = x.User.Email,

                }).FirstAsync();

            customRequest.DeliveryCompaniesNames = await dbContext.DeliveryCompanies.Select(x => x.Name).ToArrayAsync();
            if (await SeeIfUserIsACustomerAsync(customRequest.EmailAddress))
            {
                var customer = await dbContext.Customers.FirstOrDefaultAsync(x => x.User.UserName == customRequest.EmailAddress);
                CustomerViewModel customerViewModel = new CustomerViewModel()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                };
                customRequest.CustomerViewModel = customerViewModel;


            }
            return customRequest;
        }

        public async Task<IEnumerable<CustomRequestViewModel>> GetRequestsFromUserAsync(string userId)
        {
            var customRequests = await dbContext.CustomRequests
                .Where(x => x.UserId == userId && x.IsAccepted == true)
               .Select(x => new CustomRequestViewModel()
               {
                   RequestId = x.Id,
                   ProductId = x.CustomProductId,
                   Name = x.CustomProduct.Name,
                   ImageUrl = x.CustomProduct.ImageId,
                   Description = x.CustomProduct.Description,
                   Size = x.CustomProduct.Size,
                   Quantity = x.CustomProduct.Quantity,
                   EmailAddress = x.User.Email,
                   Price = x.Price.ToString(),
                   Date = x.Date

               }).ToArrayAsync();
            return customRequests;
        }

        public async Task DeleteRequestAsync(Guid id)
        {
            var customRequests = await dbContext.CustomRequests
                .FirstOrDefaultAsync(x => x.Id == id);
            var customProduct = await dbContext.CustomProducts
                .FirstOrDefaultAsync(x => x.Id == customRequests.CustomProductId);

            dbContext.CustomRequests.Remove(customRequests);
            dbContext.CustomProducts.Remove(customProduct);

            await dbContext.SaveChangesAsync();
        }

        public async Task AcceptRequestAsync(CustomRequestViewModel model)
        {
            var customRequests = await dbContext.CustomRequests
               .FirstOrDefaultAsync(x => x.Id == model.RequestId);
            customRequests.Price = Decimal.Parse(model.Price);
            customRequests.Date = model.Date;
            customRequests.IsAccepted = true;
            await dbContext.SaveChangesAsync();

        }

        public async Task AddCustomOrderAsync(CustomRequestViewModel request)
        {
            if (!await SeeIfUserIsACustomerAsync(request.EmailAddress))
            {
                Customer customer = new Customer()
                {
                    FirstName = request.CustomerViewModel.FirstName,
                    LastName = request.CustomerViewModel.LastName,
                    Address = request.CustomerViewModel.Address,
                    User = dbContext.Users
                    .Where(x => x.Email == request.EmailAddress)
                    .First()
                };
                CustomOrder customOrder = new CustomOrder()
                {
                    Customer = customer,
                    ProduductId = request.ProductId,
                    DeliveryCompanyId = dbContext.DeliveryCompanies
                    .Where(x => x.Name == request.CustomerViewModel.DeliveryCompanyName)
                    .Select(x => x.Id)
                    .First(),

                };
                dbContext.Customers.Add(customer);
                dbContext.CustomOrders.Add(customOrder);
                dbContext.CustomRequests.Remove(dbContext.CustomRequests.FirstOrDefault(x => x.Id == request.RequestId)!);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                var customer = await dbContext.Customers.FirstOrDefaultAsync(x => x.User.Email == request.EmailAddress);
                if (customer.Address != request.CustomerViewModel.Address)
                {
                    customer.Address = request.CustomerViewModel.Address;
                }
                CustomOrder customOrder = new CustomOrder()
                {
                    Customer = customer,
                    ProduductId = request.ProductId,
                    DeliveryCompanyId = dbContext.DeliveryCompanies
                  .Where(x => x.Name == request.CustomerViewModel.DeliveryCompanyName)
                  .Select(x => x.Id)
                  .First(),

                };
                dbContext.CustomOrders.Add(customOrder);
                dbContext.CustomRequests.Remove(dbContext.CustomRequests.FirstOrDefault(x => x.Id == request.RequestId)!);
                await dbContext.SaveChangesAsync();

            }

        }

        public async Task<bool> SeeIfUserIsACustomerAsync(string userId)
        {
            var customer = await dbContext.Customers.FirstOrDefaultAsync(x => x.User.Email == userId);
            if (customer == null)
            {
                return false;
            }
            return true;
        }

        public async Task<CustomRequestViewModel> GetRequestByAdminAsync(Guid id)
        {
            var customRequest = await dbContext.CustomRequests
                .Where(x => x.Id == id)
                .Select(x => new CustomRequestViewModel()
                {
                    RequestId = x.Id,
                    ProductId = x.CustomProductId,
                    Name = x.CustomProduct.Name,
                    ImageUrl = x.CustomProduct.ImageId,
                    Description = x.CustomProduct.Description,
                    Size = x.CustomProduct.Size,
                    Quantity = x.CustomProduct.Quantity,
                    EmailAddress = x.User.Email,

                }).FirstAsync();
            return customRequest;

        }
    }
}
