namespace Hovercraft.Models
{
	public class TooltipLocatorModel
	{
		public string Locator { get; set; }
		public string BackgroundColor { get; set; }
		public string TextColor { get; set; }
		public TooltipModel Tooltip { get; set; }
	}
}