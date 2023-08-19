namespace GiftShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
   

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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return this.View("Error404");
            }

            return this.View();
        }
    }
}