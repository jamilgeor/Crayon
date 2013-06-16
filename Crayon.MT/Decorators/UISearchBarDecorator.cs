using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UISearchBar), "search-bar")]
	public class UISearchBarDecorator : BaseDecorator<UISearchBar>
	{
		[StyleProperty(typeof(StyleBackgroundColorProperty))]
		public override void SetBackgroundColor (StyleBackgroundColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			if (property.Global)
				UISearchBar.Appearance.TintColor = color;
			else
				View.TintColor = color;
		}
	}
}

