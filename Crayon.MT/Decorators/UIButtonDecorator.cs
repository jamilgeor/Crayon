using System;
using MonoTouch.UIKit;

using Crayon;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIButton))]
	public class UIButtonDecorator : BaseDecorator
	{
		UIButton View { get { return (UIButton)Control; } }

		[StyleProperty(typeof(StyleColorProperty))]
		public void SetColor(StyleColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);
			View.SetTitleColor (color, UIControlState.Normal);
		}

		[StyleProperty(typeof(StyleFontFamilyProperty))]
		public void SetFontFace(StyleFontFamilyProperty property)
		{
			View.Font = UIFont.FromName (property.FontName, View.Font.PointSize);
		}

		[StyleProperty(typeof(StyleFontSizeProperty))]
		public void SetFontSize(StyleFontSizeProperty property)
		{
			View.Font = UIFont.FromName (View.Font.Name, property.Size);
		}
	}
}

