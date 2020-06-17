using System.Collections.Generic;
using Hovercraft.Models;
using Microsoft.AspNetCore.Mvc;

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
			return GetTooltip(website);
		}

		IEnumerable<TooltipLocatorModel> GetTooltip(string website)
		{
			if(website.Contains("hovercraft.azurewebsites.net") || website.Contains("localhost"))
				return GetDummyPageTooltips();
			if (website.Contains("ospokolenko.wixsite.com/nonsense"))
				return GetOspokolenkoWixSiteTooltips();

			return new TooltipLocatorModel[0];
		}

		IEnumerable<TooltipLocatorModel> GetDummyPageTooltips()
		{
			return new[]
			{
				new TooltipLocatorModel
				{
					Locator = @"td:contains(""Varndagroth"")",
					Tooltip = new TooltipModel
					{
						IconUrl = "https://www.neoseeker.com/timespinner/File:Timespinner_varndagroth_icon.jpg",
						Header = "Varndagroth",
						Lines = new []
						{
							"Location: Varndagray Metropolis",
							"HP: 800",
							"Exp: 100",
							"Strong vs: Dark",
							"Weak vs: Fire, Ice, Light"
						}
					}
				},
				new TooltipLocatorModel
				{
					Locator = @"td:contains(""Aelana"")",
					Tooltip = new TooltipModel
					{
						IconUrl = "https://www.neoseeker.com/timespinner/File:Timespinner_aelana_icon.jpg",
						Header = "Aelana",
						Lines = new []
						{
							"Location: Royal Towers",
							"HP: 2250",
							"Exp: 300",
							"Strong vs: Lightning ",
							"Weak vs: Aura, Dark"
						}
					}
				}
			};
		}

		IEnumerable<TooltipLocatorModel> GetOspokolenkoWixSiteTooltips()
		{
			return new[]
			{
				new TooltipLocatorModel
				{
					Locator = @"#comp-kbj2wv741label",
					Tooltip = new TooltipModel
					{
						Lines = new []
						{
							"Join the most forward-thinking accountants and let them share the experience"
						}
					}
				}
			};
		}
	}
}
