namespace GiftShop.Web.Tests
{
    using GiftShop.Services.EmailSender.Contracts;
    using GiftShop.Services.EmailSender;
    using Moq;
    using Xunit;
    using System.Net.Mail;
    using Microsoft.Extensions.Configuration;
    using static GiftShop.Common.EmailMessagesConstants;

    public class EmailSenderServiceTests
    {
        [Fact]
        public void SendEmail_ValidParameters_CallsSmtpClientSend()
        {

            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(conf => conf["MySecrets:Email"]).Returns("giftsmadebyandy@gmail.com");
            configurationMock.Setup(conf => conf["MySecrets:Password"]).Returns("buhloqelmmgugdic");

            var smtpClientMock = new Mock<ISmtpClientService>();
            var emailSenderService = new EmailSenderService(configurationMock.Object, smtpClientMock.Object);


            emailSenderService.SendEmail("recipient@example.com", "Test Subject", "Test Description", "Test Ending");

            smtpClientMock.Verify(
          client => client.Send(
              It.IsAny<MailMessage>(),
              "giftsmadebyandy@gmail.com",
              "buhloqelmmgugdic"
          ),
          Times.Once
      );
        }
        [Fact]
        public void SendEmail_ValidParameters_CallsSmtpClientSendWithValidEmail()
        {

            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(conf => conf["MySecrets:Email"]).Returns("giftsmadebyandy@gmail.com");
            configurationMock.Setup(conf => conf["MySecrets:Password"]).Returns("mlujygldzfnudhzm");

            var smtpClientMock = new Mock<ISmtpClientService>();
            var emailSenderService = new EmailSenderService(configurationMock.Object, smtpClientMock.Object);


            emailSenderService.SendEmail("recipient@example.com", AcceptedCustomRequestSubject, AcceptedCustomRequestBody, Ending);

            smtpClientMock.Verify(
          client => client.Send(
              It.IsAny<MailMessage>(),
              "giftsmadebyandy@gmail.com",
              "mlujygldzfnudhzm"
          ),
          Times.Once
      );
        }
    }
}


