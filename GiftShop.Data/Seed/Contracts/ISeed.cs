namespace GiftShop.Data.Seed.Contracts
{
    public interface ISeed
    {
        public Task Seed(GiftShopDbContext dbContext, IServiceProvider serviceProvider);
    }
}

