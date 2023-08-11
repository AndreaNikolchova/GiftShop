namespace GiftShop.Services.CustomProducts.Contracts
{
    using GiftShop.Web.ViewModels.CustomProduct;
    using GiftShop.Web.ViewModels.DeliveryCompany;
    using GiftShop.Web.ViewModels.Packaging;

    public interface ICustomProductService
    {
        public Task AddCustomRequestAsync(CustomProductViewModel product);
        public Task<IEnumerable<CustomRequestViewModel>> GetAllRequestsAsync();
        public Task<CustomRequestViewModel> GetRequestByUserAsync(Guid id);
        public Task<CustomRequestViewModel> GetRequestByAdminAsync(Guid id);
        public Task<IEnumerable<CustomRequestViewModel>> GetRequestsFromUserAsync(string userId);
        public Task DeleteRequestAsync(Guid id, bool admin);
        public Task AcceptRequestAsync(CustomRequestViewModel model, string email);
        public Task<bool> SeeIfUserIsACustomerAsync(string userId);
        public Task<IEnumerable<DeliveryCompanyViewModel>> GetDeliveryCompaniesAsync();
        public Task<IEnumerable<PackagingViewModel>> GetPackagingAsync();
    }
}
