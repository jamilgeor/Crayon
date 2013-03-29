using System;
using Crayon;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIToolbar))]
	public class UIToolbarDecorator : BaseDecorator<UIToolbar>
	{
		[StyleProperty(typeof(StyleBackgroundColorProperty))]
		public override void SetBackgroundColor (StyleBackgroundColorProperty property)
		{
			View.TintColor = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);
		}

		[StyleProperty(typeof(StyleBackgroundImageProperty))]
		public override void SetBackgroundImage(StyleBackgroundImageProperty property)
		{
			View.SetBackgroundImage (UIImage.FromFile (property.ImageUrl), UIToolbarPosition.Any, UIBarMetrics.Default);
		}
	}
}

