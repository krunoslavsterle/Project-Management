using System;
using System.Net.Mail;

namespace PM.Common.Clients
{
    public class EmailClient : IDisposable
    {
        private SmtpClient smtpClient;
        private MailAddress mailAddress;

        public EmailClient()
        {
            smtpClient = new SmtpClient();
            smtpClient.Host = "localhost";

            mailAddress = new MailAddress("admin@pm.mail.com");
        }

        public async void SendEmail(string subject, string body, string address)
        {   
            var message = new MailMessage();
            message.From = mailAddress;
            message.To.Add(new MailAddress(address));

            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            message.To.Add(new MailAddress(address)); 
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {              
                await smtp.SendMailAsync(message);
            }
        }

        public void Dispose()
        {
            smtpClient = null;
            mailAddress = null;
        }
    }
}
