namespace GiftShop.Services.CustomProducts.Contracts
{
    using GiftShop.Web.ViewModels.CustomProduct;
    public interface ICustomProductService
    {
        public Task AddCustomRequest(CustomProductViewModel product);
        public Task<IEnumerable<CustomRequestViewModel>> GetAllRequests();
        public Task<CustomRequestViewModel> GetRequestByUser(Guid id);
        public Task<CustomRequestViewModel> GetRequestByAdmin(Guid id);
        public Task AddCustomOrder(CustomRequestViewModel request);
        public Task<IEnumerable<CustomRequestViewModel>> GetRequestsFromUser(string userId);
        public Task DeleteRequest(Guid id);
        public Task AcceptRequest(CustomRequestViewModel model);
        public Task<bool> SeeIfUserIsACustomer(string userId);
    }
}
