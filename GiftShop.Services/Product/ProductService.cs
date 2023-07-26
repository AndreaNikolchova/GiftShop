namespace GiftShop.Services.Product
{
    using GiftShop.Data;
    using GiftShop.Services.ImageService.Contracts;
    using GiftShop.Services.Product.Contracts;
    using GiftShop.ViewModels.Product;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        public GiftShopDbContext dbContext { get; set; }
        private IMediaService mediaService;

        public ProductService(GiftShopDbContext dbContext, IMediaService mediaService)
        {
            this.dbContext = dbContext;
            this.mediaService = mediaService;
        }

        public async Task<IEnumerable<ProductViewModelHomePage>> GetProductFromEveryCategory()
        {
            var products = await this.dbContext.Products.Take(3)
                .Select(p => new ProductViewModelHomePage()
                {
                    Name = p.Name,
                    ImageUrl = p.ImageUrl

                })
                
                .ToArrayAsync();
            return products;
        }
    }
}
