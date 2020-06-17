using System.Collections.Generic;
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
			return GetDummyCustomerTooltips();
		}

		IEnumerable<TooltipLocatorModel> GetDummyCustomerTooltips()
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
						Header = "Varndagroth Borealis",
						Lines = new []
						{
							"Royal Tower 1",
							"457753 RYL Vilete",
							"https://www.neoseeker.com/timespinner/Walkthrough/Boss_Aelana"

						}
					}
				}
			};
		}
	}
}
