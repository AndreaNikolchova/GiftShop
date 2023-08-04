using GiftShop.Data;
using GiftShop.Models;
namespace GiftShop.Services.CustomProducts
{
    using GiftShop.Services.EmailSender.Contracts;
    using GiftShop.Services.ImageService.Contracts;
    using GiftShop.Services.Product.Contracts;
    using GiftShop.Web.ViewModels.CustomProduct;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;


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

        public async Task AddCustomRequest(CustomProductViewModel product)
        {
            string picture;
            if (product.Photo != null)
            {
                try
                {
                    picture = await this.mediaService.UploadPicture(product.Photo, product.Name);
                    CustomProduct customProduct = new CustomProduct()
                    {
                        Description = product.Description,
                        Size = product.Size,
                        Name = product.Name,
                        ImageId = picture,
                        Quantity = product.Quantity,
                    };
                    await dbContext.AddAsync<CustomProduct>(customProduct);
                    CustomRequest request = new CustomRequest()
                    {
                        CustomProduct = customProduct,
                        UserId = product.User!,
                        IsAccepted = false
                    };
                    await dbContext.AddAsync<CustomRequest>(request);
                    await dbContext.SaveChangesAsync();
                    emailSender.SendEmail(product.EmailAddress, "Your request has been send succsessfully", "Your custom order");

                }
                catch (InvalidOperationException e)
                {
                    throw e;
                }
            }
            else
            {
                CustomProduct customProduct = new CustomProduct()
                {
                    Description = product.Description,
                    Size = product.Size,
                    Name = product.Name,
                    Quantity = product.Quantity,
                };
                await dbContext.AddAsync<CustomProduct>(customProduct);
                CustomRequest request = new CustomRequest()
                {
                    CustomProduct = customProduct,
                    UserId = product.User!,
                    IsAccepted = false
                };
                await dbContext.AddAsync<CustomRequest>(request);

                await dbContext.SaveChangesAsync();
                emailSender.SendEmail(product.EmailAddress, "Your request has been send succsessfully", "Your custom order");
            }

        }


        public async Task<IEnumerable<CustomRequestViewModel>> GetAllRequests()
        {
            var customRequests = await dbContext.CustomRequests
                .Where(x=>x.IsAccepted==false)
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

        public async Task<CustomRequestViewModel> GetRequest(Guid id)
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

        public Task MakeCustomOrder(CustomRequestViewModel request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomRequestViewModel>> GetRequestsFromUser(string userId)
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
                   Price =x.Price.ToString(),
                   Date = x.Date

               }).ToArrayAsync();
            return customRequests;
        }

        public async Task DeleteRequest(Guid id)
        {
            var customRequests = await dbContext.CustomRequests
                .FirstOrDefaultAsync(x => x.Id == id);
            var customProduct = await dbContext.CustomProducts
                .FirstOrDefaultAsync(x => x.Id == customRequests.CustomProductId);

            dbContext.CustomRequests.Remove(customRequests);
            dbContext.CustomProducts.Remove(customProduct);

            await dbContext.SaveChangesAsync();
        }

        public async Task AcceptRequest(CustomRequestViewModel model)
        {
            var customRequests = await dbContext.CustomRequests
               .FirstOrDefaultAsync(x => x.Id == model.RequestId);
            customRequests.Price = Decimal.Parse(model.Price);
            customRequests.Date = model.Date;
            customRequests.IsAccepted = true;
            await dbContext.SaveChangesAsync();


        }
    }
}
