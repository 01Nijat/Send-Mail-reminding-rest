using MailKit;
using Microsoft.AspNetCore.Mvc;
using sendmail.Interfaces;
using sendmail.Model;

namespace sendmail.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendMailController : Controller
    {
        public readonly IMailSendService _mailService;
        public SendMailController(IMailSendService mailService)
        {
            this._mailService = mailService;
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromForm]MailRequest request)
        {
            try
            {
                await _mailService.SendEmailAsync(request);
                    return Ok();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
