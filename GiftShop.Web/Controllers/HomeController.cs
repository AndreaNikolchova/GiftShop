namespace GiftShop.Web.Controllers
{
    using System.Diagnostics;
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using GiftShop.Web.ViewModels.Home;
    using GiftShop.Services.Product.Contracts;
    using GiftShop.Web.ViewModels.Cart;

    [Authorize]
    public class HomeController : Controller
    {
        private IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetLast3ProductsAsync();
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}