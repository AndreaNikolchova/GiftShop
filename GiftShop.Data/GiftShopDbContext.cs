using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GiftShop.Data
{
    public class GiftShopDbContext : IdentityDbContext
    {
        public GiftShopDbContext(DbContextOptions<GiftShopDbContext> options)
            : base(options)
        {

        }
    }
}