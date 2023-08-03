﻿namespace GiftShop.Services.Product
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GiftShop.Data;
    using GiftShop.Models;
    using GiftShop.Services.EmailSender.Contracts;
    using GiftShop.Services.ImageService.Contracts;
    using GiftShop.Services.Product.Contracts;
    using GiftShop.Web.ViewModels.CustomProduct;
    using GiftShop.Web.ViewModels.Product;
    using Microsoft.EntityFrameworkCore;
    public class ProductService : IProductService
    {
        public GiftShopDbContext dbContext { get; set; }
        private IEmailSenderService emailSender;
        private IMediaService mediaService;

        public ProductService(GiftShopDbContext dbContext, IMediaService mediaService,IEmailSenderService emailSender)
        {
            this.dbContext = dbContext;
            this.mediaService = mediaService;
            this.emailSender = emailSender;

        }

        public async Task<IEnumerable<ProductViewModel>> GetProductFromEveryCategory()
        {
            var products = await this.dbContext.Products.Take(3)
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price.ToString(),
                    Description = p.Description!,
                    Type = p.Type.Name

                })

                .ToArrayAsync();
            return products;
        }


        public async Task<IEnumerable<ProductViewModel>> GetAll(string productType)
        {
            var products = await this.dbContext.Products.Where(x => x.Type.Name == productType)
                   .Select(p => new ProductViewModel()
                   {
                       Id = p.Id,
                       Name = p.Name,
                       ImageUrl = p.ImageUrl,
                       Price = p.Price.ToString(),
                       Description = p.Description!,


                   })
                   .ToArrayAsync();
            return products;
        }

        public async Task<ProductDetailsViewModel> GetDetails(Guid id)
        {
            var product = await dbContext.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    Size = p.Size,
                    Price = p.Price.ToString(),
                    Type = p.Type.Name,
                    YarnName = p.YarnType.Name,
                })
                .ToArrayAsync();
            return product[0];
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
                        UserId = product.User!
                    };
                    await dbContext.AddAsync<CustomRequest>(request);
                    await dbContext.SaveChangesAsync();
                    emailSender.SendEmail(product.EmailAddress,"Your request has been send succsessfully", "Your custom order");

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
                    UserId = product.User!
                };
                await dbContext.AddAsync<CustomRequest>(request);
                await dbContext.SaveChangesAsync();
                emailSender.SendEmail(product.EmailAddress, "Your request has been send succsessfully", "Your custom order");

            }

        }
    }
}
