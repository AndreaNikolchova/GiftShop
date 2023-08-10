
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
                  Name = "Ekont Avtomat",
                  Price =6m
                },
                 new DeliveryCompany()
                {
                  Id = Guid.Parse("20adea35-fc7d-4d09-a08d-c1565da80428"),
                  Name = "Ekont to your address",
                  Price =7m
                },
                 new DeliveryCompany()
                {
                  Id = Guid.Parse("41be4560-ba27-46c7-a75c-5dfe69339302"),
                  Name = "Speedy to your address",
                   Price =8m
                },
                  new DeliveryCompany()
                {
                  Id = Guid.Parse("32399eb3-76c3-4c96-8b63-1ae65d949175"),
                  Name = "Speedy Avtomat",
                   Price =4.16m
                },
                  new DeliveryCompany()
                {
                  Id = Guid.Parse("692078e5-eaed-48f6-b513-c81fe669f8c3"),
                  Name = "Sameday to your address",
                   Price =5.88m
                },
                  new DeliveryCompany()
                {
                  Id = Guid.Parse("49ce683b-bd2d-4d6c-8d3f-fea4395cefe6"),
                  Name = "Sameday Avtomat",
                   Price =3.48m
                }
            };
            return deliveryCompanies.ToArray();

        }
    }
}
