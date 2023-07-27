namespace GiftShop.Services.Product
{
    using GiftShop.Data;
    using GiftShop.Services.ImageService.Contracts;
    using GiftShop.Services.Product.Contracts;
    using GiftShop.ViewModels.Product;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        public GiftShopDbContext dbContext { get; set; }

        public ProductService(GiftShopDbContext dbContext, IMediaService mediaService)
        {
            this.dbContext = dbContext;

        }

        public async Task<IEnumerable<ProductViewModel>> GetProductFromEveryCategory()
        {
            var products = await this.dbContext.Products.Take(3)
                .Select(p => new ProductViewModel()
                {
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
    }
}
