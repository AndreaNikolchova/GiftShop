using Microsoft.AspNetCore.Mvc;

namespace GiftShop.Web.Controllers
{
    public class CustomOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
