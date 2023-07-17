using GiftShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GiftShop.Data
{
    public class GiftShopDbContext : DbContext
    {
        public GiftShopDbContext(DbContextOptions<GiftShopDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}