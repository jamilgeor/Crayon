using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UITabBar))]
	public class UITabBarDecorator : BaseDecorator<UITabBar>
	{
		[StyleProperty(typeof(StyleBackgroundColorProperty))]
		public override void SetBackgroundColor (StyleBackgroundColorProperty property)
		{
			View.TintColor = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);
		}
	}
}

