namespace GiftShop.Web.Controllers
{
    using GiftShop.Services.Order.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static GiftShop.Common.ApplicationConstants;
    public class OrderController : Controller
    {
        private IOrderService orderService;

        public OrderController(IOrderService customOrderService)
        {
            this.orderService = customOrderService;
        }
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Index()
        {
            var model = await orderService.GetAllOrdersAsync();
            return View(model);
        }
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Done(Guid id)
        {
            await orderService.MarkAnOrderAsDoneAsync(id);
            return Redirect("/Order/Index");
        }
    }
}
