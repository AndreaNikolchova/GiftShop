namespace GiftShop.Web.Controllers
{
    using GiftShop.Services.Product.Contracts;
    using GiftShop.Web.ViewModels.Cart;
    using GiftShop.Web.ViewModels.Product;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [Authorize]
    public class ProductController : Controller
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Add()
        {
            AddProductViewModel model = await productService.FillTypesAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await productService.AddProductAsync(model);
                    return Redirect($"/{model.Type}");
                }
                catch (InvalidOperationException e)
                {
                    model.PhotoError = e.Message;
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] ProductToAddToCartViewModel model)
        {
            await productService.AddToCartAsync(Guid.Parse(model.ProductId), User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Redirect($"/{model.ControllerName}/Index");
        }

    }
}
