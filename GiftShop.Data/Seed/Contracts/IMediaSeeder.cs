namespace GiftShop.Data.Seed.Contracts
{
    public interface IMediaSeeder
    {
        public Task<string> UploadPicture(string path);
    }
}
