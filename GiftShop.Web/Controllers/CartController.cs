namespace GiftShop.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using GiftShop.Services.Cart.Contracts;
    using GiftShop.Web.ViewModels.Cart;

    [Authorize]
    public class CartController : Controller
    {
        private ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
       
        public async Task<IActionResult> Index()
        {
            var model = await cartService.GetCartInformationAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(model);
        }
        public async Task<IActionResult> Remove()
        {
            var model = await cartService.GetCartInformationAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(model);
        }
        public IActionResult Order(CartViewModel model)
        {
            return View(model);
        }
    }
}
