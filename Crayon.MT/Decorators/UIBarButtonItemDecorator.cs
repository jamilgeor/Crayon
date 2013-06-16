using System;
using Crayon;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIBarButtonItem), "bar-button")]
	public class UIBarButtonItemDecorator : IControlDecorator
	{
		UIBarButtonItem _view;

		public void SetControl(object control)
		{
			_view = (UIBarButtonItem)control;
		}

		[StyleProperty(typeof(StyleBackgroundColorProperty))]
		public void SetBackgroundColor(StyleBackgroundColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			if (property.Global)
				UIBarButtonItem.Appearance.TintColor = color;
			else
				_view.TintColor = color;
		}

		[StyleProperty(typeof(StyleBackgroundImageProperty))]
		public void SetBackgroundColor(StyleBackgroundImageProperty property)
		{
			var image = UIImage.FromFile (property.ImageUrl);

			if (property.Global) {
				UIBarButtonItem.Appearance.SetBackgroundImage (image, UIControlState.Normal, UIBarMetrics.Default);
				UIBarButtonItem.Appearance.SetBackButtonBackgroundImage (image, UIControlState.Normal, UIBarMetrics.Default);
			} else {
				_view.SetBackgroundImage(image, UIControlState.Normal, UIBarMetrics.Default);
				_view.SetBackButtonBackgroundImage (image, UIControlState.Normal, UIBarMetrics.Default);

			}
		}
	}
}

