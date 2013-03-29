using System;
using Crayon;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIBarButtonItem))]
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
			_view.TintColor = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);;
		}
	}
}

