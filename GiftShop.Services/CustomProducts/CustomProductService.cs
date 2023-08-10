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
            emailSender.SendEmail(product.EmailAddress, CustomRequestSubject, CustomRequestBody, Ending);


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
            emailSender.SendEmail(this.dbContext.Users.Where(x=>x.Id==customRequests.UserId).Select(x=>x.UserName).First(), DeletedCustomRequestSubject, DeletedCustomRequestBody, Ending);
        }

        public async Task AcceptRequestAsync(CustomRequestViewModel model, string email)
        {
            var customRequests = await dbContext.CustomRequests
               .FirstOrDefaultAsync(x => x.Id == model.RequestId);
            customRequests.Price = Decimal.Parse(model.Price);
            customRequests.Date = model.Date;
            customRequests.IsAccepted = true;
            await dbContext.SaveChangesAsync();
            emailSender.SendEmail(email, AcceptedCustomRequestSubject, AcceptedCustomRequestBody, Ending);

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
