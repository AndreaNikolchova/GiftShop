namespace GiftShop.Web.Controllers
{
    using GiftShop.Services.Product.Contracts;
    using GiftShop.Web.ViewModels.CustomProduct;
    using Microsoft.AspNetCore.Mvc;
    public class CustomProductController : Controller
    {
        private IProductService productService;

        public CustomProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CustomProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                await productService.AddCustomOrder(model);
            }
            return View();
        }
    }
}
