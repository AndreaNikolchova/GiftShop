namespace GiftShop.Web.Controllers
{
    using GiftShop.Services.Product.Contracts;
    using GiftShop.Web.ViewModels.CustomProduct;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using static GiftShop.Common.ApplicationConstants;

    [Authorize]
    public class CustomProductController : Controller
    {
        private IProductService productService;

        public CustomProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            return View();
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
                    await productService.AddCustomRequest(model);
                    return Redirect("Home/Index");
                }
                catch(InvalidOperationException e)
                {
                    model.PhotoError = e.Message;
                    return View(model);
                }
               
            }
            return View(model);
        }

        //[Authorize(Roles = AdminRoleName)]
        //public async Task<IActionResult> Request()
        //{

        //}
    }
}
