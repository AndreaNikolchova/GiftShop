namespace GiftShop.Services.CustomProducts.Contracts
{
    using GiftShop.Web.ViewModels.CustomProduct;
    public interface ICustomProductService
    {
        public Task AddCustomRequestAsync(CustomProductViewModel product);
        public Task<IEnumerable<CustomRequestViewModel>> GetAllRequestsAsync();
        public Task<CustomRequestViewModel> GetRequestByUserAsync(Guid id);
        public Task<CustomRequestViewModel> GetRequestByAdminAsync(Guid id);
        public Task<IEnumerable<CustomRequestViewModel>> GetRequestsFromUserAsync(string userId);
        public Task DeleteRequestAsync(Guid id);
        public Task AcceptRequestAsync(CustomRequestViewModel model, string email);
        public Task<bool> SeeIfUserIsACustomerAsync(string userId);
    }
}
