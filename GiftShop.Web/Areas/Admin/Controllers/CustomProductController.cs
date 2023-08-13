namespace GiftShop.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using GiftShop.Services.CustomProducts.Contracts;
    using GiftShop.Web.ViewModels.CustomProduct;
    using static GiftShop.Common.ApplicationConstants;
    [Area(AdminAreaName)]
    public class CustomProductController : BaseAdminController
    {
        private ICustomProductService productService;

        public CustomProductController(ICustomProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var customProducts = await productService.GetAllRequestsAsync();
            return View(customProducts);
        }

        public async Task<IActionResult> Accept(Guid id)
        {
            var model = await productService.GetRequestByAdminAsync(id);
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> Accept(CustomRequestViewModel model)
        {
            await productService.AcceptRequestAsync(model, model.EmailAddress);
            return Redirect("/CustomProduct/Request");
        }


    }
}
