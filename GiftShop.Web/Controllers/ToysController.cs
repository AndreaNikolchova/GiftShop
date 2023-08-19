using GiftShop.Services.Product.Contracts;
using GiftShop.Web.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GiftShop.Web.Controllers
{
    public class ToysController : Controller
    {
        private IProductService productService;

        public ToysController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var toys = await productService.GetAllAsync("Toys");
            return View(toys);
        }
     
        public async Task<IActionResult> Details(Guid id)
        {
            var product = await this.productService.GetDetailsAsync(id);
            return View(product);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.productService.DeleteAsync(id);
            return Redirect("/Toys/Index");
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
