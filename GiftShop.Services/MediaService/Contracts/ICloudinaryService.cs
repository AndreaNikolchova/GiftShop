using CloudinaryDotNet.Actions;


namespace GiftShop.Services.MediaService.Contracts
{
    public interface ICloudinaryService
    {
        Task<ImageUploadResult> UploadAsync(ImageUploadParams parameters);
    }
}
