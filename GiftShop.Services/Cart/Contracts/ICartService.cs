namespace GiftShop.Services.Cart.Contracts
{
using GiftShop.Web.ViewModels.Cart;
    public interface ICartService
    {
        public Task<CartViewModel> GetCartInformationAsync(string userId);
    }
}
