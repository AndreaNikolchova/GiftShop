namespace GiftShop.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using GiftShop.Services.Product.Contracts;
    using GiftShop.Web.ViewModels.Product;
    using static GiftShop.Common.ApplicationConstants;

    [Area(AdminAreaName)]
    public class ProductController : BaseAdminController
    {
        private IProductService productService;

        public ProductController (IProductService productService)
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
