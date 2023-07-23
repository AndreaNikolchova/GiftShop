using GiftShop.Data.Seed.Contracts;
using GiftShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShop.Data.Seed
{
    public class YarnSeeder : ISeed
    {
        public async Task Seed(GiftShopDbContext dbContext, IServiceProvider serviceProvider)
        {
            List<YarnType> yarnTypes = new List<YarnType>()
            {
                new YarnType()
                {
                  Id = new Guid(),
                  Name = "Alize Puffy",
                },
                 new YarnType()
                {
                  Id = new Guid(),
                  Name = "Baby Bunny",
                },
                  new YarnType()
                {
                  Id = new Guid(),
                  Name = "Alexander Yarn Ide",
                }
            };
            foreach (var yarnType in yarnTypes)
            {
                var dbSource = dbContext.ProductTypes.FirstOrDefault(x => x.Name == yarnType.Name);
                if (dbSource == null)
                {
                    dbContext.YarnTypes.Add(
                        new YarnType
                        {
                            Id = yarnType.Id,
                            Name = yarnType.Name
                        });
                }
                else
                {
                    dbSource.Name = yarnType.Name;

                }
            }
        }
    }
}

