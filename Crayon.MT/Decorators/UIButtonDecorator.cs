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

		[StyleProperty(typeof(StyleFontFamilyProperty))]
		public void SetFontFace(StyleFontFamilyProperty property)
		{
			_buttonView.Font = UIFont.FromName (property.FontName, _buttonView.Font.PointSize);
		}

		[StyleProperty(typeof(StyleFontSizeProperty))]
		public void SetFontSize(StyleFontSizeProperty property)
		{
			_buttonView.Font = UIFont.FromName (_buttonView.Font.Name, property.Size);
		}
	}
}

