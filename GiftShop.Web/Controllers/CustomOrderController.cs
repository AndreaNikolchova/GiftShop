namespace GiftShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using GiftShop.Services.CustomOrder.Contracts;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class CustomOrderController : Controller
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
