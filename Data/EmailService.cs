using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HealthSystem.Data
{
    public class EmailService
    {
        private readonly string _gmailSmtpServer = "smtp.gmail.com";
        private readonly int _port = 587; // 465 for SSL, 587 for TLS
        private readonly string _emailFrom = "master20802@gmail.com";
        private readonly string _password = Environment.GetEnvironmentVariable("GMAIL_PASSWORD", EnvironmentVariableTarget.User) ?? "";

        public async Task SendEmailAsync(string recipientEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient(_gmailSmtpServer)
            {
                Port = _port,
                Credentials = new NetworkCredential(_emailFrom, _password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailFrom),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(recipientEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }

        public async Task SendEmailWithImageAsync(string recipientEmail, string subject, string body, string base64Image)
        {
            var smtpClient = new SmtpClient(_gmailSmtpServer)
            {
                Port = _port,
                Credentials = new NetworkCredential(_emailFrom, _password),
                EnableSsl = true
            };

            var imageBytes = Convert.FromBase64String(base64Image.Replace("data:image/png;base64,", ""));

            using (var mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(_emailFrom);
                mailMessage.To.Add(recipientEmail);
                mailMessage.Subject = subject;

                // Add body with the linked image
                var htmlBody = $"{body}<br><img src='cid:InlineImage' />";
                var alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");

                // Create the inline image
                var linkedImage = new LinkedResource(new MemoryStream(imageBytes), "image/png")
                {
                    ContentId = "InlineImage",
                    TransferEncoding = System.Net.Mime.TransferEncoding.Base64
                };
                alternateView.LinkedResources.Add(linkedImage);

                mailMessage.AlternateViews.Add(alternateView);

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }

}
