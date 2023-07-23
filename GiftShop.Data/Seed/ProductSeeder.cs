using GiftShop.Data.Seed.Contracts;
using GiftShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GiftShop.Data.Seed
{
    public class ProductSeeder : ISeed
    {
        private IMediaSeeder seeder;
        public async Task Seed(ModelBuilder modelBuilder)
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Id = new Guid(),
                    Name = "Blanket",
                    ImageId = await seeder.UploadPicture(@"C:\Users\Adi\Desktop\photos for giftshop\IMG_4014.jpeg"),
                    Price = 130.00m,
                    Description = "Blue soft blanket",
                    Size = "100x180 cm",
                    Quantity = 1,
                    ProductTypeId = dbContext.ProductTypes.FirstOrDefault(pt=>pt.Name == "Accessories")!.Id,
                    YarnTypeId =  dbContext.YarnTypes.FirstOrDefault(pt=>pt.Name == "Alize Puffy")!.Id
                },
                 new Product()
                {
                    Id = new Guid(),
                    Name = "Roses",
                    ImageId = await seeder.UploadPicture(@"C:\Users\Adi\Desktop\photos for giftshop\IMG_8323.jpeg"),
                    Price = 130.00m,
                    Description = "A buquet of 5 roses",
                    Size = "25 cm",
                    Quantity = 2,
                    ProductTypeId = dbContext.ProductTypes.FirstOrDefault(pt=>pt.Name == "Accessories")!.Id,
                    YarnTypeId =  dbContext.YarnTypes.FirstOrDefault(pt=>pt.Name == "Alize Puffy")!.Id
                },
                    new Product()
                {
                    Id = new Guid(),
                    Name = "Baby Dear",
                    ImageId = await seeder.UploadPicture(@"C:\Users\Adi\Desktop\photos for giftshop\IMG_3999.jpeg"),
                    Price = 130.00m,
                    Description = "This baby dear is so adorable and a perfect Xmas gift.The scarf is with a custom color which should be added in the notes when you order :)",
                    Size = "20 cm",
                    Quantity = 1,
                    ProductTypeId = dbContext.ProductTypes.FirstOrDefault(pt=>pt.Name == "Toys")!.Id,
                    YarnTypeId =  dbContext.YarnTypes.FirstOrDefault(pt=>pt.Name == "Baby Bunny")!.Id
                }
            };
            foreach (var product in products)
            {
              
                    dbContext.Products.Add(
                        new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            ImageId = product.ImageId,
                            Price = product.Price,
                            ProductTypeId = product.ProductTypeId,
                            YarnTypeId = product.YarnTypeId,
                            Description = product.Description,
                            Size = product.Size,
                            Quantity = product.Quantity

                        });
               
                else
                {
                    dbSource.Name = product.Name;
                    dbSource.ImageId = product.ImageId;
                    dbSource.Price = product.Price;
                    dbSource.ProductTypeId = product.ProductTypeId;
                    dbSource.YarnTypeId = product.YarnTypeId;
                    dbSource.Description = product.Description;
                    dbSource.Size = product.Size;
                    dbSource.Quantity = product.Quantity;
                }
            }
        }
    }
}
