namespace GiftShop.Web.Controllers
{
    using System.Diagnostics;
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using GiftShop.Web.ViewModels.Home;
    using GiftShop.Services.Product.Contracts;

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
        
        public async Task<IActionResult> AddToCart(Guid id)
        {
            await productService.AddToCartAsync(id, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Redirect("/Home/Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}