using Microsoft.AspNetCore.Mvc;

namespace Hovercraft.Controllers
{
	[Route("")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}