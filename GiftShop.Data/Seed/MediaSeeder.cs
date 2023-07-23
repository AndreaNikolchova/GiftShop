using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using GiftShop.Data.Seed.Contracts;

namespace GiftShop.Data.Seed
{
    public class MediaSeeder : IMediaSeeder
    {
        private Cloudinary cloudinary;

        public MediaSeeder(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }
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
