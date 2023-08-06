﻿using GiftShop.Services.Product.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GiftShop.Web.Controllers
{
    public class AccessoriesController : Controller
    {
        private IProductService productService;

        public AccessoriesController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var accessories = await productService.GetAllAsync("Accessories");
            return View(accessories);

        }

        public async Task<IActionResult> Details(Guid id)
        {
            var product = await this.productService.GetDetailsAsync(id);
            return View(product);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.productService.DeleteAsync(id);
            return Redirect("/Index");
        }
    }
}
