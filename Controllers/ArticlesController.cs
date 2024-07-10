using Microsoft.AspNetCore.Mvc;

namespace Nontakan.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
