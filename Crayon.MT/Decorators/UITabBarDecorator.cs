using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UITabBar), "tab-bar")]
	public class UITabBarDecorator : BaseDecorator<UITabBar>
	{
		[StyleProperty(typeof(StyleBackgroundColorProperty))]
		public override void SetBackgroundColor (StyleBackgroundColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			if (property.Global)
				UITabBar.Appearance.TintColor = color;
			else
				View.TintColor = color;
		}
	}
}

