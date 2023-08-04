namespace GiftShop.Services.Product.Contracts
{
    using GiftShop.Web.ViewModels.CustomProduct;
    public interface ICustomProductService
    {
        public Task AddCustomRequest(CustomProductViewModel product);
        public Task<IEnumerable<CustomRequestViewModel>> GetAllRequests();
        public Task<CustomRequestViewModel> GetRequest(Guid id);
    }
}
