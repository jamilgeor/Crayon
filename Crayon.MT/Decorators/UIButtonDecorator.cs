using System;
using MonoTouch.UIKit;

using Crayon;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIButton))]
	public class UIButtonDecorator : IControlDecorator
	{
		UIButton _buttonView;
		
		public void SetControl(object control)
		{
			_buttonView = (UIButton)control;
		}

		[StyleProperty(typeof(StyleColorProperty))]
		public void SetColor(StyleColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);
			_buttonView.SetTitleColor (color, UIControlState.Normal);
		}
	}
}

