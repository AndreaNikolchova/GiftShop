namespace GiftShop.Services.Cart.Contracts
{
using GiftShop.Web.ViewModels.Cart;
    public interface ICartService
    {
        public Task<CartViewModel> GetCartInformationAsync(string userId);
        public Task RemoveProductFromCart(string userId, Guid productId);
    }
}
