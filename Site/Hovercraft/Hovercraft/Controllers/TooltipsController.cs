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
			if (website.Contains("accounting.twinfield.com"))
				return GetTwinfieldSalesToolTips();

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
				},
				new TooltipLocatorModel
				{
					Locator = @"#comp-kbjc9eya0label",
					Tooltip = new TooltipModel
					{
						Header = "Home",
						Lines = new [] { "Here you can find out all latest accounting information" }
					}
				},
				new TooltipLocatorModel
				{
					Locator = @"#comp-kbjc9eya1linkElement",
					Tooltip = new TooltipModel
					{
						Header = "Donation",
						Lines = new [] { "If you feel inspired about our web-site, you are welcome to help us" }
					}
				},
				new TooltipLocatorModel
				{
					Locator = @"#comp-kbjc9eya2label",
					Tooltip = new TooltipModel
					{
						Header = "About",
						Lines = new [] { "The story about our members" }
					}
				},
				new TooltipLocatorModel
				{
					Locator = @"#comp-kbjc9eya3label",
					Tooltip = new TooltipModel
					{
						Header = "Blog",
						Lines = new [] { "Join the most forward-thinking accountants and let them share the experience" }
					}
				},
				new TooltipLocatorModel
				{
					Locator = @"#comp-kbjc9eya4label",
					Tooltip = new TooltipModel
					{
						Header = "Yelp Review",
						Lines = new [] { "Check comments and starts on Yelp" }
					}
				},
				new TooltipLocatorModel
				{
					Locator = @"#comp-kbjc9eya5label",
					Tooltip = new TooltipModel
					{
						Header = "Knowledge Base",
						Lines = new [] { "Check out the accounting syllabus" }
					}
				},
			};
		}

		IEnumerable<TooltipLocatorModel> GetTwinfieldSalesToolTips()
		{
			return new[]
			{
				new TooltipLocatorModel
				{
					Locator = @"div.flex-list-container div:contains('Irfan Coleman')",
					Tooltip = new TooltipModel
					{
						Lines = new []
						{
							"Not Here 345",
							"4626 ;D",
							"Kiev - Ukraine",
							"687-628785174",
							"icoleman@wolterskluwer.com"
						}
					}
				},
				new TooltipLocatorModel
				{
					Locator = @"div.flex-list-container div:contains('108.000,00')",
					Tooltip = new TooltipModel
					{
						Header = "Items",
						Lines = new []
						{
							"2x Pet Dragon €54000,00",
						}
					}
				},
				new TooltipLocatorModel
				{
					Locator = @"div .flex-list-container div:contains('Quentin Weaver')",
					Tooltip = new TooltipModel
					{
						Lines = new []
						{
							"Australishestraat 8925",
							"6395 :D",
							"Amersfoort - Netherlands",
							"qweaver@wolterskluwer.com"
						}
					}
				},
				new TooltipLocatorModel
				{
					Locator = @"div .flex-list-container div:contains('100.000,00')",
					Tooltip = new TooltipModel
					{
						Header = "Items",
						Lines = new []
						{
							"1x WK Code Games Victory €100000,00",
						}
					}
				},
				new TooltipLocatorModel
				{
					Locator = @"div .flex-list-container div:contains('Leia Mcgregor')",
					Tooltip = new TooltipModel
					{
						Lines = new []
						{
							"Somewhere Nearby 40",
							"3563264 ZIP",
							"Knowhere - Netherlands",
							"06-3095783545",
							"admin@leiamcgregor.com"
						}
					}
				},
				new TooltipLocatorModel
				{
					Locator = @"div .flex-list-container div:contains('78.050,00')",
					Tooltip = new TooltipModel
					{
						Header = "Items",
						Lines = new []
						{
							"1x Electric Car €78.000,00",
							"5x Pen 50,00"
						}
					}
				}
			};
		}
	}
}
