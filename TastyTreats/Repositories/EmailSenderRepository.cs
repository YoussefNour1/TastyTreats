
using Microsoft.Extensions.Options;
using TastyTreats.Models;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;
namespace TastyTreats.Repositories
{
    public class EmailSenderRepository : IEmailSenderRepository
    {

        private readonly EmailSettings _emailSettings;

        public EmailSenderRepository(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

      
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var emailMessage = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_emailSettings.SenderEmail),
                Subject = subject
            };
            emailMessage.To.Add(MailboxAddress.Parse(toEmail));
            emailMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));


            var builder = new BodyBuilder
            {
                HtmlBody = message
            };
            emailMessage.Body = builder.ToMessageBody();

            // Send the email
            try
            {
                using var smtp = new SmtpClient();
                // Connect to the SMTP server
                await smtp.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, SecureSocketOptions.StartTls);

                // Authenticate
                await smtp.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.SenderPassword);

                // Send the email
                await smtp.SendAsync(emailMessage);

                // Disconnect
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new InvalidOperationException("Failed to send email.", ex);
            }
        }

    }



    
}
