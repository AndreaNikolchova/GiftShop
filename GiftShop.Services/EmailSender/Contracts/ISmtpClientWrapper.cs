namespace GiftShop.Services.EmailSender.Contracts
{
    using System.Net.Mail;
    public interface ISmtpClientWrapper
    {
        void Send(MailMessage message,string email, string password);
    }
}
