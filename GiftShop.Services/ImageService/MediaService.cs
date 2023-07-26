namespace GiftShop.Services.ImageService
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using GiftShop.Services.ImageService.Contracts;
    public class MediaService : IMediaService
    {
        private Cloudinary cloudinary;

        public MediaService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

       // public string GetImageUrl(string id)
        //{
        //    var item = cloudinary.GetResource(new GetResourceParams(id));
        //    return cloudinary.GetResource(new GetResourceParams(id)).Url; 
        //}

        public async Task<string> UploadPicture(string path)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(path),

            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            string publicId = uploadResult.PublicId;
            return publicId;
        }
    }
}
