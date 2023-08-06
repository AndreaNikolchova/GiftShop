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
            var clothes = await productService.GetAllAsync("Clothes");
            return View(clothes);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.productService.DeleteAsync(id);
            return Redirect("/Index");
        }
    }
}
