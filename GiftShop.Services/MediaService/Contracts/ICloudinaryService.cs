namespace GiftShop.Services.MediaService.Contracts
{
    using CloudinaryDotNet.Actions;
    public interface ICloudinaryService
    {
        Task<ImageUploadResult> UploadAsync(ImageUploadParams parameters);
    }
}
