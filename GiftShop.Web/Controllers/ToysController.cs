﻿using GiftShop.Services.Product.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GiftShop.Web.Controllers
{
    public class ToysController : Controller
    {
        private IProductService productService;

        public ToysController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var toys = await productService.GetAll("Toys");
            return View(toys);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var product = await this.productService.GetDetails(id);
            return View(product);
        }
    }
}
