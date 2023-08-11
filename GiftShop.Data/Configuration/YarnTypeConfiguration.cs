namespace GiftShop.Data.Configuration
{
    using GiftShop.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class YarnTypeConfiguration : IEntityTypeConfiguration<YarnType>
    {
        public void Configure(EntityTypeBuilder<YarnType> builder)
        {
           builder.HasData(this.Seed());
        }

        public YarnType[] Seed()
        {
            HashSet<YarnType> yarnTypes = new HashSet<YarnType>()
                {
                    new YarnType()
                    {
                      Id = Guid.Parse("33db593a-7a2b-493d-ae3c-f35086510855"),
                      Name = "Alize Puffy",
                    },
                     new YarnType()
                    {
                      Id = Guid.Parse("fa6e1ffc-2094-4b9d-a985-305443b7ef27"),
                      Name = "Baby Bunny",
                    },
                      new YarnType()
                    {
                      Id = Guid.Parse("d9ff2381-dcad-4a99-b2f7-2c8a34af34b2"),
                      Name = "Alexander Yarn Ira",
                    }
                };
            return yarnTypes.ToArray();
        }
    }
}

