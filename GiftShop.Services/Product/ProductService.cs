namespace GiftShop.Services.Product
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GiftShop.Data;
    using GiftShop.Models;
    using GiftShop.Services.EmailSender.Contracts;
    using GiftShop.Services.ImageService.Contracts;
    using GiftShop.Services.Product.Contracts;
    using GiftShop.Web.ViewModels.Product;
    using Microsoft.EntityFrameworkCore;
    public class ProductService : IProductService
    {
        private IMediaService mediaService;

        public GiftShopDbContext dbContext { get; set; }

        public ProductService(GiftShopDbContext dbContext, IMediaService mediaService)
        {
            this.dbContext = dbContext;
            this.mediaService = mediaService;
        }

        public async Task<IEnumerable<ProductViewModel>> GetLast3ProductsAsync()
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


        public async Task<IEnumerable<ProductViewModel>> GetAllAsync(string productType)
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

        public async Task<ProductDetailsViewModel> GetDetailsAsync(Guid id)
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
                .FirstAsync();
            return product;
        }

        public async Task AddProductAsync(AddProductViewModel addProductViewModel)
        {
            try
            {

                var picture = await this.mediaService.UploadPicture(addProductViewModel.Photo, addProductViewModel.Name);


                var yarnType = await dbContext.YarnTypes
                    .FirstOrDefaultAsync(x => x.Name == addProductViewModel.YarnType);
                var newYarnType = new YarnType()
                {
                    Name = addProductViewModel.Name
                };


                Product product = new Product()
                {
                    Name = addProductViewModel.Name,
                    ImageUrl = picture,
                    Description = addProductViewModel.Description,
                    Size = addProductViewModel.Size,
                    Quantity = addProductViewModel.Quantity,
                    Price = decimal.Parse(addProductViewModel.Price),
                    ProductTypeId = await dbContext.ProductTypes
                        .Where(x => x.Name == addProductViewModel.Type)
                        .Select(x => x.Id)
                        .FirstAsync(),
                    YarnTypeId = yarnType != null ? yarnType.Id : newYarnType.Id,
                };
                if (yarnType == null)
                {
                    await dbContext.YarnTypes.AddAsync(newYarnType);
                }
                await dbContext.Products.AddAsync(product);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AddProductViewModel> FillTypesAsync()
        {
            var types = await dbContext.ProductTypes
                .Select(x => x.Name).ToArrayAsync();
            AddProductViewModel model = new AddProductViewModel();
            model.Types = types;
            return model;

        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();

        }

        public async Task<EditProductViewModel> GetDetailsForEditAsync(Guid id)
        {
            var types = await dbContext.ProductTypes
                .Select(x => x.Name).ToArrayAsync();
            var product = await dbContext.Products
                .Where(x => x.Id == id)
                .Select(x => new EditProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    Quantity = x.Quantity,
                    Size = x.Size,
                    Price = x.Price.ToString(),
                    Type = x.Type.Name,
                    Types = types,
                    YarnType = x.YarnType.Name,
                })
                .FirstAsync();
            return product;
        }

        public async Task UpdateProductInformation(EditProductViewModel model)
        {
            var product = await dbContext.Products
               .FirstOrDefaultAsync(x => x.Id == model.Id);
            if (model.Photo != null)
            {
                var picture = await this.mediaService.UploadPicture(model.Photo, model.Name);
                product!.ImageUrl = picture;
            }
            else
            {
                product!.ImageUrl = model.ImageUrl;
            }
            product.Name = model.Name;
            product.Description = model.Description;
            product.Size = model.Size;
            product.Price = decimal.Parse(model.Price);
            product.Quantity = model.Quantity;
            if (dbContext.ProductTypes.Where(x=>x.Id == product.ProductTypeId).First().Name != model.Type)
            {
                product.ProductTypeId = await dbContext.ProductTypes
                    .Where(x => x.Name == model.Type)
                    .Select(x => x.Id)
                    .FirstAsync();
            }
            if (dbContext.YarnTypes.Where(x => x.Id == product.YarnTypeId).First().Name != model.YarnType)
            {
                product.YarnTypeId = await dbContext.YarnTypes
                    .Where(x => x.Name == model.YarnType)
                    .Select(x => x.Id)
                    .FirstAsync();
            }
            await dbContext.SaveChangesAsync();
        }

    }
}
