using System;
using Crayon;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIToolbar), "toolbar")]
	public class UIToolbarDecorator : BaseDecorator<UIToolbar>
	{
		[StyleProperty(typeof(StyleBackgroundColorProperty))]
		public override void SetBackgroundColor (StyleBackgroundColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			if (property.Global)
				UIToolbar.Appearance.TintColor = color;
			else
				View.TintColor = color;
		}

		[StyleProperty(typeof(StyleBackgroundImageProperty))]
		public override void SetBackgroundImage(StyleBackgroundImageProperty property)
		{
			if (property.Global)
				UIToolbar.Appearance.SetBackgroundImage (UIImage.FromFile (property.ImageUrl), UIToolbarPosition.Any, UIBarMetrics.Default);
			else
				View.SetBackgroundImage (UIImage.FromFile (property.ImageUrl), UIToolbarPosition.Any, UIBarMetrics.Default);
		}
	}
}

