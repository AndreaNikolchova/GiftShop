using GiftShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace GiftShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Cloudinary _cloudinary;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            // Access the uploaded image URL
            string imageUrl = uploadResult.SecureUrl.ToString();

            // Process the URL as needed

            return View();
        }

        public async Task<IActionResult> UploadImage()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}