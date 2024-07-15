using EmailNotification.Models;

namespace EmailNotification.Services
{
    public interface IMailService
    {
        bool SendMail(MailData mailData, string Template);
        Task<bool> SendMailAsync(MailData mailData, string Template);
    }
}
