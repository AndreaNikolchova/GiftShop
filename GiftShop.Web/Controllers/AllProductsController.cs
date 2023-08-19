using GiftShop.Services.Product.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GiftShop.Web.Controllers
{
    public class AllProductsController : Controller
    {
        private IProductService productService;

        public AllProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var model = await productService.GetAllAsync(searchString);
            return View(model);
        }
    }
}
