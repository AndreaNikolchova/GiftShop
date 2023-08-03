namespace GiftShop.Services.ImageService.Contracts
{
    using Microsoft.AspNetCore.Http;
    public interface IMediaService
    {
        public Task<string> UploadPicture(IFormFile file,string name);
        // public string GetImageUrl(string id);
    }
}
