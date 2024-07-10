using Microsoft.AspNetCore.Mvc;

namespace Nontakan.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
