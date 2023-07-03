namespace GiftShop.Contracts
{
    using Microsoft.AspNetCore.Http;
    public interface ICloudStorageService
    {
        public Task<string> GetSignedUrlAsync(string fileNameToRead, int timeOutInMinutes = 30);
        public Task<string> UploadFileAsync(IFormFile fileToUpload, string fileNameToSave);
        public Task DeleteFileAsync(string fileNameToDelete);
    }
}
