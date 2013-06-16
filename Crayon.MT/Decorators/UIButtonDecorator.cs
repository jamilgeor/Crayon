using System;
using MonoTouch.UIKit;

using Crayon;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIButton), "button")]
	public class UIButtonDecorator : BaseDecorator<UIButton>
	{
		[StyleProperty(typeof(StyleColorProperty))]
		public void SetColor(StyleColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			if (property.Global)
				UIButton.Appearance.SetTitleColor (color, UIControlState.Normal);
			else
				View.SetTitleColor (color, UIControlState.Normal);
		}

		[StyleProperty(typeof(StyleFontFamilyProperty))]
		public void SetFontFace(StyleFontFamilyProperty property)
		{
			if (property.Global)
				return;

			View.Font = UIFont.FromName (property.FontName, View.Font.PointSize);
		}

		[StyleProperty(typeof(StyleFontSizeProperty))]
		public void SetFontSize(StyleFontSizeProperty property)
		{
			if (property.Global)
				return;

			View.Font = UIFont.FromName (View.Font.Name, property.Size);
		}
	}
}

