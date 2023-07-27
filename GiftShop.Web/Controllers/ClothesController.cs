using GiftShop.Services.Product.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GiftShop.Web.Controllers
{
    public class ClothesController : Controller
    {
        private IProductService productService;

        public ClothesController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var toys = await productService.GetAll("Clothes");
            return View(toys);
        }
    }
}
