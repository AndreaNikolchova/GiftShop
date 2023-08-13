namespace GiftShop.Web.Areas.Admin.Controllers
{
    using GiftShop.Services.Order.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class OrderController : BaseAdminController
    {
        private IOrderService orderService;

        public OrderController(IOrderService customOrderService)
        {
            this.orderService = customOrderService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await orderService.GetAllOrdersAsync();
            return View(model);
        }
        public async Task<IActionResult> Done(Guid id)
        {
            await orderService.MarkAnOrderAsDoneAsync(id);
            return Redirect("/Order/Index");
        }
    }
}
