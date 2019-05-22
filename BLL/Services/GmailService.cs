using Entity.ViewModels;
using System.Net;
using System.Net.Mail;

namespace BLL.Services
{
    public class GmailService : IEmailService
    {
        public void SendMail(EmailViewModel email)
        {
            var fromAddress = new MailAddress("info@alisveris.com", "Alisveris.Com");
            var toAddress = new MailAddress(email.To);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("gercekGmail E-posta", "Gercek Sifre")
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = email.Subject,
                Body = email.Message,
                IsBodyHtml = email.IsHtml
            })
            {
                smtp.Send(message);
            }
        }
    }
}
