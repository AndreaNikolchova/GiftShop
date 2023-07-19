using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShop.Data
{
    public class GiftShopDbContext : DbContext
    {
        public GiftShopDbContext(DbContextOptions<GiftShopDbContext> options) : base(options)
        {
        }
    }
}
