using Microsoft.AspNetCore.Mvc;

namespace Nontakan.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
