﻿namespace GiftShop.Web.Controllers
{
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

        public CustomProductController(ICustomProductService productService)
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
                catch (InvalidOperationException e)
                {
                    model.PhotoError = e.Message;
                    return View(model);
                }

            }
            return View(model);
        }

        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Request()
        {
            var customProducts = await productService.GetAllRequests();
            return View(customProducts);

        }

        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Accept(Guid id)
        {
            var model = await productService.GetRequestByAdmin(id);
            return View(model);

        }
        [Authorize(Roles = AdminRoleName)]
        [HttpPost]
        public async Task<IActionResult> Accept(CustomRequestViewModel model)
        {
            await productService.AcceptRequest(model);
            return Redirect("/CustomProduct/Request");
        }
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await productService.DeleteRequest(id);
            return Redirect("/CustomProduct/Request");
        }
        public async Task<IActionResult> MyRequest()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customApprovedRequests = await productService.GetRequestsFromUser(userId);
            return View(customApprovedRequests);

        }
       
        public async Task<IActionResult> Send(Guid id)
        {
            var model = await productService.GetRequestByUser(id);
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> Send(CustomRequestViewModel model)
        {
            await productService.AddCustomOrder(model);
            return Redirect("/CustomProduct/MyRequest");
        }
    }
}
