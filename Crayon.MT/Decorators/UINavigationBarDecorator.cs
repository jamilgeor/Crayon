using System.Drawing;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UINavigationBar))]
	public class UINavigationBarDecorator : BaseDecorator<UINavigationBar>
	{
		[StyleProperty(typeof(StyleBackgroundColorProperty))]
		public override void SetBackgroundColor (StyleBackgroundColorProperty property)
		{
			View.TintColor = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);
		}

		[StyleProperty(typeof(StyleBackgroundImageProperty))]
		public override void SetBackgroundImage (StyleBackgroundImageProperty property)
		{
			View.SetBackgroundImage (UIImage.FromFile(property.ImageUrl), UIBarMetrics.Default);
		}
	}
}

