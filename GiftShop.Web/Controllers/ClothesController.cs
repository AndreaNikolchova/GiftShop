using GiftShop.Services.Product.Contracts;
using GiftShop.Web.ViewModels.Product;
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
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await productService.GetDetailsForEditAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await productService.UpdateProductInformation(model);
            return Redirect($"/{model.Type}");

        }
    }
}
