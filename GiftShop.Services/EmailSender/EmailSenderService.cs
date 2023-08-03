namespace GiftShop.Services.EmailSender
{
    using GiftShop.Services.EmailSender.Contracts;
    using System.Net;
    using System.Net.Mail;
    using Microsoft.Extensions.Configuration;

    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration configuration;

        public EmailSenderService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void SendEmail(string email, string description, string subject)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("giftsmadebyandy@gmail.com");
            message.To.Add(email);
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = "<h3>Hi,</h3>" + "<p>" + description + "</p>";

            string bussinessEmail = this.configuration["MySecrets:Email"];
            string password = this.configuration["MySecrets:Password"];

            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(bussinessEmail, password);
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(message);
            }

        }
    }
}
