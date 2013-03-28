using System;
using MonoTouch.UIKit;

using Crayon;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UILabel))]
	public class UILabelDecorator : BaseDecorator
	{
		UILabel View { get { return (UILabel)Control; } }

		[StyleProperty(typeof(StyleColorProperty))]
		public void SetTextColor(StyleColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			View.TextColor = color;
		}

		[StyleProperty(typeof(StyleTextAlignProperty))]
		public void SetTextAlignment(StyleTextAlignProperty property)
		{
			View.TextAlignment = Helpers.ConvertAlignment(property.Alignment);
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

