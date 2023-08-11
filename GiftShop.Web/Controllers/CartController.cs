namespace GiftShop.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Newtonsoft.Json;

    using GiftShop.Services.Cart.Contracts;
    using GiftShop.Web.ViewModels.Cart;
    using GiftShop.Services.Order.Contracts;
    using GiftShop.Web.ViewModels.Order;
    using GiftShop.Services.CustomProducts.Contracts;

    [Authorize]
    public class CartController : Controller
    {
        private ICartService cartService;
        private IOrderService orderService;
        private ICustomProductService productService;

        public CartController(ICartService cartService, IOrderService orderService, ICustomProductService productService)
        {
            this.cartService = cartService;
            this.orderService = orderService;
            this.productService = productService;
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
                HttpContext.Session.SetString("cart", serializedModel);
                return RedirectToAction("Order");
            }
            return View(model);
        }
        public async Task<IActionResult> Order()
        {
            var model = JsonConvert.DeserializeObject<CartViewModel>(HttpContext.Session.GetString("cart"));
            var orderModel = await orderService.FillOrderViewModel(model);
            return View(orderModel);
        }
        [HttpPost]
        public async Task<IActionResult> Order(OrderViewModel order)
        {
            if (order.DeliveryCompany == 0)
            {
                order.DeliveryCompanyNames = await productService.GetDeliveryCompaniesAsync();
                order.Packagings = await productService.GetPackagingAsync();
                ModelState.AddModelError("DeliveryCompany", "Please select a delivery company.");
                return View(order);

            }    
            await orderService.AddOrder(order, User.FindFirstValue(ClaimTypes.NameIdentifier), User.FindFirstValue(ClaimTypes.Name));
            return Redirect("/Home/Index");
        }
    }
}
