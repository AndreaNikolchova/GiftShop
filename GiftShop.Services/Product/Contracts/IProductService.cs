namespace GiftShop.Services.Product.Contracts
{
    using GiftShop.Web.ViewModels.Product;
    public interface IProductService
    {
        public Task<IEnumerable<ProductViewModel>> GetLast3ProductsAsync();
        public Task<IEnumerable<ProductViewModel>> GetAllAsync(string productType);
        public Task<ProductDetailsViewModel> GetDetailsAsync(Guid id);
        public Task AddProductAsync(AddProductViewModel addProductViewModel);
        public Task<AddProductViewModel> FillTypesAsync();
        public Task DeleteAsync(Guid id);
    }
}
