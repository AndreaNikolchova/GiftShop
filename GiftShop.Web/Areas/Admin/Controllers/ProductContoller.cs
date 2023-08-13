namespace GiftShop.Web.Areas.Admin.Controllers
{
    using GiftShop.Services.Product.Contracts;
    using GiftShop.Web.ViewModels.Product;
    using Microsoft.AspNetCore.Mvc;
    public class ProductContoller : BaseAdminController
    {
        private IProductService productService;

        public ProductContoller(IProductService productService)
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

    }
}
