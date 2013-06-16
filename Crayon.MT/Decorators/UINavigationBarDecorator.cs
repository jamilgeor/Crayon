using System.Drawing;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UINavigationBar), "navigation-bar")]
	public class UINavigationBarDecorator : BaseDecorator<UINavigationBar>
	{
		[StyleProperty(typeof(StyleBackgroundColorProperty))]
		public override void SetBackgroundColor (StyleBackgroundColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			if(property.Global)
				UINavigationBar.Appearance.TintColor = color;
			else
				View.TintColor = color;
		}

		[StyleProperty(typeof(StyleBackgroundImageProperty))]
		public override void SetBackgroundImage (StyleBackgroundImageProperty property)
		{
			if(property.Global)
				UINavigationBar.Appearance.SetBackgroundImage (UIImage.FromFile(property.ImageUrl), UIBarMetrics.Default);
			else
				View.SetBackgroundImage (UIImage.FromFile(property.ImageUrl), UIBarMetrics.Default);
		}
	}
}

