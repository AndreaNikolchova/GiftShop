using GiftShop.Data.Seed.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace GiftShop.Data.Seed
{
    public class ApplicationDbContextSeeder 
    {

        public static void Seed(ModelBuilder builder)
        {

            var seeders = new List<ISeed>
                          {
                             new ProductSeeder(),
                             new ProductTypeSeeder(),
                             new ProductSeeder()
                          };

            foreach (var seeder in seeders)
            {

                seeder.Seed(dbContext, serviceProvider);
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
                dbContext.SaveChanges();
            }
        }
    }
}
