namespace GiftShop.Services.EmailSender
{
    using GiftShop.Services.EmailSender.Contracts;
    using System.Net;
    using System.Net.Mail;
    using Microsoft.Extensions.Configuration;
    using GiftShop.Services.CustomProducts;
    using GiftShop.Services.MediaService;
    using Microsoft.EntityFrameworkCore;

    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration configuration;
        private readonly ISmtpClientService smtpClientWrapper;
        public EmailSenderService(IConfiguration configuration, ISmtpClientService smtpClientWrapper)
        {
            this.configuration = configuration;
            this.smtpClientWrapper = smtpClientWrapper;
        }
        public void SendEmail(string email, string subject, string description, string ending)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("giftsmadebyandy@gmail.com");
            message.To.Add(email);
            message.Subject = subject;
            message.IsBodyHtml = true;
            var stringArrayBody = description.Split('/');
            var stringArrayEnding = ending.Split('/');
            message.Body = $"<h2>{stringArrayBody[0]}</h2>";
            for(int i = 1; i < stringArrayBody.Length; i++)
            {
                message.Body += $"<p>{stringArrayBody[i]}</p>";
            }
            message.Body += $"<h3>{stringArrayEnding[0]}</h3>";
            for (int i = 1; i < stringArrayEnding.Length; i++)
            {
                message.Body += $"<p>{stringArrayEnding[i]}</p>";
            }

            string bussinessEmail = this.configuration["MySecrets:Email"];
            string password = this.configuration["MySecrets:Password"];

           this.smtpClientWrapper.Send(message, bussinessEmail, password);

        }
      
    }
}
