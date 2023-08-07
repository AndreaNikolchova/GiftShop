namespace GiftShop.Services.MediaService.Contracts
{
    using Microsoft.AspNetCore.Http;
    public interface IMediaService
    {
        public Task<string> UploadPictureAsync(IFormFile file,string name);
    }
}
