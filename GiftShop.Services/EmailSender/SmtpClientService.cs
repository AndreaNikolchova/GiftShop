using GiftShop.Services.EmailSender.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GiftShop.Services.EmailSender
{
    public class SmtpClientService : ISmtpClientService
    {
       
        public void Send(MailMessage message, string bussinessEmail, string password)
        {
            using (SmtpClient client = new SmtpClient())
            {

                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(bussinessEmail, password);
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
            }
        }
    }
}
