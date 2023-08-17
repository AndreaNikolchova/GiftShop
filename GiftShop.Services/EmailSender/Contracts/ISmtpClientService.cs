namespace GiftShop.Services.EmailSender.Contracts
{
    using System.Net.Mail;
    public interface ISmtpClientService
    {
        void Send(MailMessage message,string email, string password);
    }
}
