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
			if(website.Contains("hovercraft.azurewebsites.net"))
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
					Locator = @"//td[contains(text(),'Varndagroth Borealis')]",
					Tooltip = new TooltipModel
					{
						IconUrl = "https://www.neoseeker.com/timespinner/File:Timespinner_varndagroth_icon.jpg",
						Header = "Varndagroth Borealis",
						Lines = new []
						{
							"Varndagray Metropolis 84",
							"382553 XET Vilete",
							"https://www.neoseeker.com/timespinner/Walkthrough/Boss_Varndagroth"

						}
					}
				},
				new TooltipLocatorModel
				{
					Locator = @"//td[contains(text(),'Aelana Vilete')]",
					Tooltip = new TooltipModel
					{
						IconUrl = "https://www.neoseeker.com/timespinner/File:Timespinner_aelana_icon.jpg",
						Header = "Aelana Vilete",
						Lines = new []
						{
							"Royal Towers 1",
							"457753 RYL Vilete",
							"https://www.neoseeker.com/timespinner/Walkthrough/Boss_Aelana"

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
					Locator = @"//*[@id=""comp-kbj2wv741linkElement""] id=""comp-kbj2wv741label""",
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
