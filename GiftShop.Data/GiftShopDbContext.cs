using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GiftShop.Models;
using System.Reflection;

namespace GiftShop.Data
{
    public class GiftShopDbContext : IdentityDbContext<IdentityUser>
    {
        public GiftShopDbContext(DbContextOptions<GiftShopDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomOrder> CustomOrders { get; set; }
        public DbSet<CustomProduct> CustomProducts { get; set; }
        public DbSet<DeliveryCompany> DeliveryCompanies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Packaging> Packaging { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<YarnType> YarnTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(GiftShopDbContext)) ?? Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);
            base.OnModelCreating(builder);
            
        }
    }
}
