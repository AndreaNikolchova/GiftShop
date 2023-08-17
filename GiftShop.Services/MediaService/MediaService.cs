namespace GiftShop.Services.MediaService
{
    using Microsoft.AspNetCore.Http;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using GiftShop.Services.MediaService.Contracts;

    public class MediaService : IMediaService
    {
        private readonly ICloudinaryService cloudinaryService;
        public MediaService(ICloudinaryService cloudinaryService)
        {
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<string> UploadPictureAsync(IFormFile file,string name)
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

            var result = await this.cloudinaryService.UploadAsync(uploadParams);

            if (result.Error != null)
            {
                throw new InvalidOperationException("The file is too big. Choose a file which is less then 10.4 mb");
            }

            return result.Url.AbsoluteUri;
        }
    }
}
