
namespace GiftShop.Data.Configuration
{
    using GiftShop.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class DeliveryCompanyConfiguration : IEntityTypeConfiguration<DeliveryCompany>
    {
        public void Configure(EntityTypeBuilder<DeliveryCompany> builder)
        {
            builder.HasData(this.Seed());
        }
        private DeliveryCompany[] Seed()
        {

            HashSet<DeliveryCompany> deliveryCompanies = new HashSet<DeliveryCompany>()
            {
                new DeliveryCompany()
                {
                  Id = Guid.Parse("3505bf92-0bcd-463f-b117-9f0d8365ef66"),
                  Name = "Ekont",
                },
                 new DeliveryCompany()
                {
                  Id = Guid.Parse("41be4560-ba27-46c7-a75c-5dfe69339302"),
                  Name = "Speedy",
                },
                  new DeliveryCompany()
                {
                  Id = Guid.Parse("5f6bd9b9-d348-4dea-813c-93a1a365f288"),
                  Name = "Box Now",
                },
                    new DeliveryCompany()
                {
                  Id = Guid.Parse("49ce683b-bd2d-4d6c-8d3f-fea4395cefe6"),
                  Name = "Sameday",
                }
            };
            return deliveryCompanies.ToArray();

        }
    }
}
