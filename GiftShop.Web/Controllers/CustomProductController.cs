namespace GiftShop.Web.Controllers
{
    using GiftShop.Services.CustomOrder.Contracts;
    using GiftShop.Services.CustomProducts.Contracts;
    using GiftShop.Web.ViewModels.CustomProduct;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using static GiftShop.Common.ApplicationConstants;

    [Authorize]
    public class CustomProductController : Controller
    {
        private ICustomProductService productService;
        private ICustomOrderService customOrderService;

        public CustomProductController(ICustomProductService productService, ICustomOrderService customOrderService)
        {
            this.productService = productService;
            this.customOrderService = customOrderService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            await productService.DeleteRequestAsync(id, User.IsInRole(AdminRoleName));
            return Redirect("/CustomProduct/Request");
        }
        [HttpPost]
        public async Task<IActionResult> Index(CustomProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.User = User.FindFirstValue(ClaimTypes.NameIdentifier);
                model.EmailAddress = User.FindFirstValue(ClaimTypes.Email);
                try
                {
                    await productService.AddCustomRequestAsync(model);
                    return Redirect("Home/Index");
                }
                catch (InvalidOperationException e)
                {
                    model.PhotoError = e.Message;
                    return View(model);
                }

            }
            return View(model);
        }

        public async Task<IActionResult> Request()
        {
            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index", "CustomProduct", new { Area = AdminAreaName });
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customApprovedRequests = await productService.GetRequestsFromUserAsync(userId);
            return View("RequestUser", customApprovedRequests);

        }

        public async Task<IActionResult> ConfirmOrder(Guid id)
        {
            var model = await productService.GetRequestByUserAsync(id);
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> ConfirmOrder(CustomRequestViewModel model)
        {
            if (model.DeliveryCompany == 0)
            {
                model.DeliveryCompaniesNames = await productService.GetDeliveryCompaniesAsync();
                model.PackagesNames = await productService.GetPackagingAsync();
                ModelState.AddModelError("DeliveryCompany", "Please select a delivery company.");
                return View(model);

            }
            await customOrderService.AddCustomOrderAsync(model, model.EmailAddress);
            return Redirect("/CustomProduct/Request");
        }

    }
}
