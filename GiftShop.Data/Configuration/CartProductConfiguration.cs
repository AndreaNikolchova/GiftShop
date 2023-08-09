namespace GiftShop.Data.Configuration
{
    using GiftShop.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.HasKey(e => new
            {
                e.CartId,
                e.ProductId,
            });
        }
    }
}
