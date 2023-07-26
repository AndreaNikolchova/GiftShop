namespace GiftShop.Data.Configuration
{
    using GiftShop.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(this.Seed());
        }

        private Product[] Seed()
        {
            ICollection<Product> products = new HashSet<Product>()
            {
                new Product()
                {
                    Name = "Blanket",
                    ImageUrl = "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300911/IMG_4014_yctppj.jpg",
                    Price = 130.00m,
                    Description = "Blue soft blanket",
                    Size = "100x180 cm",
                    Quantity = 1,
                    ProductTypeId = Guid.Parse("1e1ee133-0f1a-4585-89ed-e251dd84b98d"),
                    YarnTypeId = Guid.Parse("33db593a-7a2b-493d-ae3c-f35086510855")
                },
                 new Product()
                {

                    Name = "Roses",
                    ImageUrl = "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg",
                    Price = 20.00m,
                    Description = "A buquet of 5 roses",
                    Size = "25 cm",
                    Quantity = 2,
                   ProductTypeId = Guid.Parse("1e1ee133-0f1a-4585-89ed-e251dd84b98d"),
                    YarnTypeId =  Guid.Parse("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2")
                },
                    new Product()
                {

                    Name = "Baby Dear",
                    ImageUrl = "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg",
                    Price = 25.00m,
                    Description = "This baby dear is so adorable and a perfect Xmas gift.The scarf is with a custom color which should be added in the notes when you order :)",
                    Size = "20 cm",
                    Quantity = 1,
                    ProductTypeId = Guid.Parse("979b887d-03fc-4f43-91b4-1c36daae5ac5"),
                    YarnTypeId = Guid.Parse("fa6e1ffc-2094-4b9d-a985-305443b7ef27")
                }
            };
            return products.ToArray();
        }
    }

}

