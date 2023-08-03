namespace GiftShop.Services.EmailSender.Contracts
{
    public interface IEmailSenderService
    {
        public void SendEmail(string email,string description,string subject);
    }
}
