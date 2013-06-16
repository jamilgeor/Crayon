using System;
using MonoTouch.UIKit;

using Crayon;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UILabel), "label")]
	public class UILabelDecorator : BaseDecorator<UILabel>
	{
		[StyleProperty(typeof(StyleColorProperty))]
		public void SetTextColor(StyleColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			if (property.Global)
				UILabel.Appearance.TextColor = color;
			else
				View.TextColor = color;
		}

		[StyleProperty(typeof(StyleTextAlignProperty))]
		public void SetTextAlignment(StyleTextAlignProperty property)
		{
			if (property.Global)
				return;

			View.TextAlignment = Helpers.ConvertAlignment(property.Alignment);
		}

		[StyleProperty(typeof(StyleFontFamilyProperty))]
		public void SetFontFace(StyleFontFamilyProperty property)
		{
			if(property.Global)
				UILabel.Appearance.Font = UIFont.FromName (property.FontName, View.Font.PointSize);
			else
				View.Font = UIFont.FromName (property.FontName, View.Font.PointSize);
		}

		[StyleProperty(typeof(StyleFontSizeProperty))]
		public void SetFontSize(StyleFontSizeProperty property)
		{
			if(property.Global)
				UILabel.Appearance.Font = UIFont.FromName (View.Font.Name, property.Size);
			else
				View.Font = UIFont.FromName (View.Font.Name, property.Size);
		}
	}
}

