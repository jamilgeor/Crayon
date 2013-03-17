using System;
using MonoTouch.UIKit;

using Crayon;

namespace Crayon.MT
{
	[ControlHandler(typeof(UIButton))]
	public class UIButtonDecorator : IControlDecorator
	{
		UIButton _buttonView;
		
		public void SetControl(object control)
		{
			//base.SetControl (control);
			_buttonView = (UIButton)control;
		}

		[StylePropertyHandlerAttribute(typeof(StyleColorProperty))]
		public void SetWidth(StyleColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);
			_buttonView.SetTitleColor (color, UIControlState.Normal);
		}
	}
}

