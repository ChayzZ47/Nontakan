using Microsoft.AspNetCore.Mvc;

namespace Nontakan.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
