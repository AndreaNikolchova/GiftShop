using GiftShop.Data.Seed.Contracts;
using GiftShop.Models;

namespace GiftShop.Data.Seed
{
    public class ProductTypeSeeder : ISeed
    {
        public async Task Seed(GiftShopDbContext dbContext, IServiceProvider serviceProvider)
        {
            List<ProductType> productTypes = new List<ProductType>()
            {
                new ProductType()
                {
                  Id = new Guid(),
                  Name = "Toys",
                },
                 new ProductType()
                {
                  Id = new Guid(),
                  Name = "Clothes",
                },
                  new ProductType()
                {
                  Id = new Guid(),
                  Name = "Accessories",
                }
            };
            foreach (var productType in productTypes)
            {
                var dbSource = dbContext.ProductTypes.FirstOrDefault(x => x.Name == productType.Name);
                if (dbSource == null)
                {
                    dbContext.ProductTypes.Add(
                        new ProductType
                        {
                           Id=productType.Id,
                           Name = productType.Name
                        });
                }
                else
                {
                    dbSource.Name = productType.Name;
                   
                }
            }
        }
    }
}
