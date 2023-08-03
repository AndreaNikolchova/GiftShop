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


        public async Task<string> UploadPicture(IFormFile file,string name)
        {
            byte[] destinationImage;

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            destinationImage = memoryStream.ToArray();

            using var destinationStream = new MemoryStream(destinationImage);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(name, destinationStream),
                PublicId = name,
            };

            var result = await this.cloudinary.UploadAsync(uploadParams);

            if (result.Error != null)
            {
                throw new InvalidOperationException("The file is too big. Choose a file which is less then 10.4 mb");
            }

            return result.Url.AbsoluteUri;
        }
    }
}
