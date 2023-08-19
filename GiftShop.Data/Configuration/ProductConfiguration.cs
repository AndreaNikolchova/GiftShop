namespace GiftShop.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using GiftShop.Models;
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
                    Description = "Wrap yourself in the soothing comfort of our blue soft crochet blanket. Handcrafted with care, this cozy and inviting blanket features a delicate crochet pattern that adds a touch of elegance to its comforting embrace. ",
                    Size = "100x180 cm",
                    Quantity = 5,
                    ProductTypeId = Guid.Parse("1e1ee133-0f1a-4585-89ed-e251dd84b98d"),
                    YarnTypeId = Guid.Parse("33db593a-7a2b-493d-ae3c-f35086510855")
                },
                 new Product()
                {

                    Name = "Roses",
                    ImageUrl = "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300910/IMG_8323_axmhkr.jpg",
                    Price = 20.00m,
                    Description = "Elevate the ordinary with our crochet bouquet of five intricately crafted roses, a timeless and artful display that captures the essence of nature's beauty in delicate yarn. A thoughtful and lasting gift for any occasion, adding a touch of handmade elegance to your surroundings.",
                    Size = "25 cm",
                    Quantity = 5,
                   ProductTypeId = Guid.Parse("1e1ee133-0f1a-4585-89ed-e251dd84b98d"),
                    YarnTypeId =  Guid.Parse("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2")
                },
                    new Product()
                {

                    Name = "Baby Dear",
                    ImageUrl = "https://res.cloudinary.com/andysgiftshop/image/upload/v1690300909/IMG_3999_qe9com.jpg",
                    Price = 25.00m,
                    Description = "Delight in the enchanting innocence of our crochet baby deer plushie, a soft and lovable addition to any nursery that promises warmth and companionship for your little bundle of joy.",
                    Size = "20 cm",
                    Quantity = 5,
                    ProductTypeId = Guid.Parse("979b887d-03fc-4f43-91b4-1c36daae5ac5"),
                    YarnTypeId = Guid.Parse("fa6e1ffc-2094-4b9d-a985-305443b7ef27")
                },
                    new Product()
                {
                    Name = "Pillow",
                    ImageUrl = "https://res.cloudinary.com/andysgiftshop/image/upload/v1691317411/Pillow.jpg",
                    Price = 60.00m,
                    Description = "Introduce a serene touch to your living space with our blue pillow, its soothing hue and plush texture offering both aesthetic elegance and cozy comfort.",
                    Size = "40x40cm",
                    Quantity = 5,
                    ProductTypeId = Guid.Parse("1e1ee133-0f1a-4585-89ed-e251dd84b98d"),
                    YarnTypeId = Guid.Parse("33db593a-7a2b-493d-ae3c-f35086510855")
                },
                       new Product()
                {
                    Name = "Penguin",
                    ImageUrl = "https://res.cloudinary.com/andysgiftshop/image/upload/v1691694736/Penguin.jpg",
                    Price = 35.00m,
                    Description = "Meet our adorable crochet penguin, meticulously handcrafted to bring a touch of whimsy and charm into your life. With its intricate stitches and lovable design, this penguin plushie is a perfect cuddly companion for both kids and the young at heart.",
                    Size = "25cm",
                    Quantity = 5,
                    ProductTypeId = Guid.Parse("979b887d-03fc-4f43-91b4-1c36daae5ac5"),
                    YarnTypeId = Guid.Parse("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2")
                },
                        new Product()
                {
                    Name = "Leggy Froggie",
                    ImageUrl = "https://res.cloudinary.com/andysgiftshop/image/upload/v1691667795/Frog.jpg",
                    Price = 15.00m,
                    Description = "Say hello to Leggy Froggie, our delightful crochet creation that adds a playful twist to traditional plushies. With its vibrant colors, long and stretchy legs, and a cheerful smile, Leggy Froggie is ready to hop into your heart and become a cherished companion.",
                    Size = "12cm",
                    Quantity = 5,
                    ProductTypeId = Guid.Parse("979b887d-03fc-4f43-91b4-1c36daae5ac5"),
                    YarnTypeId = Guid.Parse("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2")
                },
            };
            return products.ToArray();
        }
    }

}

