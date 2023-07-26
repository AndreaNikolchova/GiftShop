namespace GiftShop.Services.ImageService.Contracts
{
    public interface IMediaService
    { 
        public Task<string> UploadPicture(string path);
       // public string GetImageUrl(string id);
    }
}
