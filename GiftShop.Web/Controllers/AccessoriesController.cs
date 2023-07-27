using GiftShop.Services.Product.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GiftShop.Web.Controllers
{
    public class AccessoriesController : Controller
    {
        private IProductService productService;

        public AccessoriesController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var accessories = await productService.GetAll("Accessories");
            return View(accessories);

        }

        public IActionResult Details(Guid id)
        {
            return View();
        }
    }
}
