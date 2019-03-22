using System;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace PM.Common.Clients
{
    public class EmailClient : IDisposable
    {
        private SendGridClient client;
        private string apiKey = "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";

        public EmailClient()
        {
            client = new SendGridClient(apiKey);
        }

        public Task SendEmail(string subject, string body, string address)
        {
            var msg = new SendGridMessage();
            msg.SetFrom("support@pmanager.com", "PManager support");
            msg.AddTo(address);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html, body);

            return client.SendEmailAsync(msg);
        }

        public void Dispose()
        {
            client = null;
        }
    }
}
