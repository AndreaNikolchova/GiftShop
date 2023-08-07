namespace GiftShop.Web.Controllers
{
    using ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using GiftShop.Services.Product.Contracts;
    public class HomeController : Controller
    {
        private IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productService.GetLast3ProductsAsync();
            return View(products);
        }
        public async Task<IActionResult> AddToCart(Guid id)
        {
            await productService.AddToCartAsync(id);
            return Redirect("/Home/Index");
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}