namespace GiftShop.Services.ImageService.Contracts
{
    using Microsoft.AspNetCore.Http;
    public interface IMediaService
    {
        public Task<string> UploadPicture(IFormFile file);
        // public string GetImageUrl(string id);
    }
}
