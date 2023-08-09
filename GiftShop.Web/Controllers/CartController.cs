namespace GiftShop.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using GiftShop.Services.Cart.Contracts;
    using GiftShop.Web.ViewModels.Cart;
    using GiftShop.Services.Order.Contracts;
    using Newtonsoft.Json;

    [Authorize]
    public class CartController : Controller
    {
        private ICartService cartService;
        private IOrderService orderService;

        public CartController(ICartService cartService, IOrderService orderService)
        {
            this.cartService = cartService;
            this.orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await cartService.GetCartInformationAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(model);
        }
        public async Task<IActionResult> Remove(Guid id)
        {
            await cartService.RemoveProductFromCart(User.FindFirstValue(ClaimTypes.NameIdentifier),id);
            return Redirect("/Cart/Index");
        }
        [HttpPost]
        public async Task<IActionResult> Index(CartViewModel model)
        {
            if (ModelState.IsValid)
            {
                string serializedModel = JsonConvert.SerializeObject(model);

                // Store the serialized model in TempData
                HttpContext.Session.SetString("cart", serializedModel);
                return RedirectToAction("Order");
            }
            return View(model);
        }
        public IActionResult Order()
        {
            var model = JsonConvert.DeserializeObject<CartViewModel>(HttpContext.Session.GetString("cart"));
            var orderModel = orderService.FillOrderViewModel(model);
            return View(orderModel);
        }
    }
}
