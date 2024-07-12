using EmailNotification.Models;

namespace EmailNotification.Services
{
    public interface IMailService
    {
        bool SendMail(MailData Mail_Data);
    }
}
