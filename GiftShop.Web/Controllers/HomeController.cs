using GiftShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GiftShop.Services.Product.Contracts;

namespace GiftShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProductFromEveryCategory();
            return View(products);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}