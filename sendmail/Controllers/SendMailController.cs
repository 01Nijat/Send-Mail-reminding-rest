using Microsoft.AspNetCore.Mvc;

namespace sendmail.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendMailController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
