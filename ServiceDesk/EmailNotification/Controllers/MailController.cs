using EmailNotification.Models;
using EmailNotification.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailNotification.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        // Injecting the IMailService into the constructor
        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        /*[HttpPost]
        public bool SendMail(MailData mailData)
        {
            return _mailService.SendMail(mailData);
        }*/

        [HttpPost("{Template}")]
        public bool SendMail(MailData mailData, string Template)
        {
            return _mailService.SendMail(mailData, Template);
        }
    }
}
