using GiftShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GiftShop.Data
{
    public class GiftShopDbContext : IdentityDbContext<Customer,IdentityRole<Guid>,Guid>
    {
        public GiftShopDbContext(DbContextOptions<GiftShopDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Customer>().ToTable("Users");
        }
    }
}