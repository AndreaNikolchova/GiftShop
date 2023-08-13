namespace GiftShop.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using GiftShop.Services.CustomOrder.Contracts;
    public class CustomOrderController : BaseAdminController
    {
        private ICustomOrderService customOrderService;

        public CustomOrderController(ICustomOrderService customOrderService)
        {
            this.customOrderService = customOrderService;
        }

        
        public async Task<IActionResult> Index()
        {
            var model = await customOrderService.GetAllOrdersAsync();
            return View(model);
        }
        public async Task<IActionResult> Done(Guid id)
        {
            await customOrderService.MarkAnOrderAsDoneAsync(id);
            return Redirect("/CustomOrder/Index");
        }
    }
}
