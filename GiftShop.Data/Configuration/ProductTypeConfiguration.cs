namespace GiftShop.Data.Configuration
{
    using GiftShop.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {

        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
           builder.HasData(this.Seed());
        }

        private ProductType[] Seed()
        {

            HashSet<ProductType> productTypes = new HashSet<ProductType>()
            {
                new ProductType()
                {
                  Id = Guid.Parse("979b887d-03fc-4f43-91b4-1c36daae5ac5"),
                  Name = "Toys",
                },
                 new ProductType()
                {
                  Id = Guid.Parse("c1143e77-ccfa-4231-bd25-49e29470f13a"),
                  Name = "Clothes",
                },
                  new ProductType()
                {
                  Id = Guid.Parse("1e1ee133-0f1a-4585-89ed-e251dd84b98d"),
                  Name = "Accessories",
                }
            };
            return productTypes.ToArray();

        }
    }
}

