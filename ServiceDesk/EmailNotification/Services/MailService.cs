using EmailNotification.Models;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;

namespace EmailNotification.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        //private readonly Serilog.ILogger _logger;

        public MailService(IOptions<MailSettings> options)
        {
            _mailSettings = options.Value;
            //_logger = logger;
        }

        public bool SendMail(MailData mailData, string Template)
        {
            return SendMailAsync(mailData, Template).GetAwaiter().GetResult();
        }

        public async Task<bool> SendMailAsync(MailData mailData, string Template)
        {
            try
            {
                var emailMessage = new MimeMessage();
                var emailFrom = new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail);
                emailMessage.From.Add(emailFrom);
                var emailTo = new MailboxAddress(mailData.EmailToName, mailData.EmailToId);
                emailMessage.To.Add(emailTo);
                emailMessage.Subject = mailData.EmailSubject;

                var bodyBuilder = new BodyBuilder();

                // Load and use the HTML template
                var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", $"{Template}.html");
                var templateContent = await File.ReadAllTextAsync(templatePath);
                bodyBuilder.HtmlBody = templateContent.Replace("{Content}", mailData.EmailBody);

                // Set the plain text body as well
                bodyBuilder.TextBody = mailData.EmailBody;

                emailMessage.Body = bodyBuilder.ToMessageBody();

                using (var mailClient = new SmtpClient())
                {
                    mailClient.Connect(_mailSettings.Server, _mailSettings.Port, false);
                    mailClient.Authenticate(_mailSettings.UserName, _mailSettings.Password);
                    await mailClient.SendAsync(emailMessage);
                    mailClient.Disconnect(true);
                }

                // Log the successful email send
                //_logger.Information("Email sent successfully: {EmailTo}, {Subject}, {Body}, {SentAt}, {Success}",
                //    mailData.EmailToId, mailData.EmailSubject, mailData.EmailBody, DateTime.UtcNow, true);

                return true;
            }
            catch (Exception ex)
            {
                // Log the failed email send
                //_logger.Error(ex, "Failed to send email: {EmailTo}, {Subject}, {Body}, {SentAt}, {Success}",
                //    mailData.EmailToId, mailData.EmailSubject, mailData.EmailBody, DateTime.UtcNow, false);

                return false;
            }
        }
    }
}
