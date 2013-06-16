using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UITextView), "text")]
	public class UITextViewDecorator : BaseDecorator<UITextView>
	{
		[StyleProperty(typeof(StyleFontFamilyProperty))]
		public void SetFontFamily(StyleFontFamilyProperty property)
		{
			if (property.Global)
				return;

			View.Font = UIFont.FromName(property.FontName, View.Font.PointSize);
		}
		
		[StyleProperty(typeof(StyleFontSizeProperty))]
		public void SetFontSize(StyleFontSizeProperty property)
		{
			if (property.Global)
				return;

			View.Font = UIFont.FromName(View.Font.Name, property.Size);
		}
		
		[StyleProperty(typeof(StyleColorProperty))]
		public void SetFontColor(StyleColorProperty property)
		{
			if (property.Global)
				return;

			View.TextColor = UIColor.FromRGBA(property.Color.R, property.Color.G, property.Color.B, property.Color.A);
		}
	}
}

