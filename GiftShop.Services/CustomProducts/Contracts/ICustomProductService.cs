namespace GiftShop.Services.Product.Contracts
{
    using GiftShop.Web.ViewModels.CustomProduct;
    public interface ICustomProductService
    {
        public Task AddCustomRequest(CustomProductViewModel product);
        public Task<IEnumerable<CustomRequestViewModel>> GetAllRequests();
        public Task<CustomRequestViewModel> GetRequest(Guid id);
        public Task MakeCustomOrder(CustomRequestViewModel request);
        public Task<IEnumerable<CustomRequestViewModel>> GetRequestsFromUser(string userId);
        public Task DeleteRequest(Guid id);
        public Task AcceptRequest(CustomRequestViewModel model);
    }
}
