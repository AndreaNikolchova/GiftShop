namespace GiftShop.Services.Product.Contracts
{
    using GiftShop.ViewModels.Product;
    public interface IProductService
    {
        public Task<IEnumerable<ProductViewModelHomePage>> GetProductFromEveryCategory();
    }
}
