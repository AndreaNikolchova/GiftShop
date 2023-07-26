using Microsoft.AspNetCore.Mvc;

namespace GiftShop.Web.Controllers
{
    public class ToysController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
