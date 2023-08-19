namespace GiftShop.Web.Controllers
{
    using GiftShop.Services.Product.Contracts;
    using GiftShop.Web.ViewModels.Cart;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    public class ProductController : Controller
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] ProductToAddToCartViewModel model)
        {
            await productService.AddToCartAsync(Guid.Parse(model.ProductId), User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Redirect($"/{model.ControllerName}/Index");
        }

    }
}
