namespace GiftShop.Services.Product.Contracts
{
    using GiftShop.Web.ViewModels.Product;
    public interface IProductService
    {
        public Task<IEnumerable<ProductViewModel>> GetProductFromEveryCategory();
        public Task<IEnumerable<ProductViewModel>> GetAll(string productType);
        public Task<ProductDetailsViewModel> GetDetails(Guid id);
    }
}
