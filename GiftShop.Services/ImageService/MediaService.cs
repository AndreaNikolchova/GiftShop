namespace GiftShop.Services.ImageService
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using GiftShop.Services.ImageService.Contracts;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;

    public class MediaService : IMediaService
    {
        private Cloudinary cloudinary;
        private IWebHostEnvironment webHostEnvironment;
        public MediaService(Cloudinary cloudinary,IWebHostEnvironment webHostEnvironment)
        {
            this.cloudinary = cloudinary;
            this.webHostEnvironment = webHostEnvironment;
        }


        public async Task<string> UploadPicture(IFormFile file)
        {

            // Generate a unique filename for the uploaded picture
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            // Save the file to a temporary location on the server
            string tempFilePath = Path.Combine(webHostEnvironment.WebRootPath, "uploads", fileName);

            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Upload the file to Cloudinary
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, new FileStream(tempFilePath, FileMode.Open)),
                PublicId = fileName, // Use the filename as the public ID
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            return uploadResult.Url.ToString();
        }
    }
}
