using GiftShop.Data;
using GiftShop.Models;
namespace GiftShop.Services.CustomProducts
{
    using GiftShop.Services.EmailSender.Contracts;
    using GiftShop.Services.ImageService.Contracts;
    using GiftShop.Services.CustomProducts.Contracts;
    using GiftShop.Web.ViewModels.CustomProduct;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using GiftShop.Web.ViewModels.Customer;

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

        public async Task<CustomRequestViewModel> GetRequestByUser(Guid id)
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
            if (await SeeIfUserIsACustomer(customRequest.EmailAddress))
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
                   Price = x.Price.ToString(),
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

        public async Task AddCustomOrder(CustomRequestViewModel request)
        {
            if (!await SeeIfUserIsACustomer(request.EmailAddress))
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

        public async Task<bool> SeeIfUserIsACustomer(string userId)
        {
            var customer = await dbContext.Customers.FirstOrDefaultAsync(x => x.User.Email == userId);
            if (customer == null)
            {
                return false;
            }
            return true;
        }

        public async Task<CustomRequestViewModel> GetRequestByAdmin(Guid id)
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
