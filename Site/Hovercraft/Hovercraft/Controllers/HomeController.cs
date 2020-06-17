using Hovercraft.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hovercraft.Controllers
{
	[Route("")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", GetTimespinnerBossModel());
        }

        TimespinnerBossModel GetTimespinnerBossModel()
        {
	        return new TimespinnerBossModel
	        {
		        Bosses = new[]
		        {
			        new BossModel {Name = "Varndagroth", Url = "https://www.neoseeker.com/timespinner/Walkthrough/Boss_Varndagroth" },
			        new BossModel {Name = "Aelana", Url = "https://www.neoseeker.com/timespinner/Walkthrough/Boss_Aelana"}
		        }
	        };
        }
    }
}