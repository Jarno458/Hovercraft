using System.Collections.Generic;
using System.IO;
using System.Linq;
using Hovercraft.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hovercraft.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TooltipsController : ControllerBase
	{
		// GET api/tooltips
		[HttpGet]
		public IEnumerable<TooltipLocatorModel> Get(string website)
		{
			using (StreamReader reader = new StreamReader("Content/Tooltips.json"))
			{
				string json = reader.ReadToEnd();
				var model = JsonConvert.DeserializeObject<WebsiteTooltipModel[]>(json);

				return model.FirstOrDefault(m => m.Websites.Any(website.Contains))?.Tooltips 
				       ?? new TooltipLocatorModel[0];
			}
		}
	}
}
