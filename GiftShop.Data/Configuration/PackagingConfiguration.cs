namespace GiftShop.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using GiftShop.Models;
    public class PackagingConfiguration : IEntityTypeConfiguration<Packaging>
    {
        public void Configure(EntityTypeBuilder<Packaging> builder)
        {
            builder.HasData(this.Seed());
        }
        private Packaging[] Seed()
        {

            HashSet<Packaging> packagingTypes = new HashSet<Packaging>()
            {
                new Packaging()
                {
                  Id = Guid.Parse("0d0cdc67-7dfc-4236-8eab-bc8021aeb942"),
                  Name = "Normal",
                  Price = 0m
                },
                 new Packaging()
                {
                  Id = Guid.Parse("ec46d5b0-38ca-4d42-a336-1151e4152c29"),
                  Name = "In a box with a bow",
                  Price= 4.5m
                },

            };
            return packagingTypes.ToArray();

        }

    }
}
