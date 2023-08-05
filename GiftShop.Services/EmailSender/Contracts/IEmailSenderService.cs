namespace GiftShop.Services.EmailSender.Contracts
{
    public interface IEmailSenderService
    {
        public void SendEmail(string email, string subject, string description, string ending);
    }
}
