using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UITextView))]
	public class UITextViewDecorator : BaseDecorator<UITextView>
	{
		[StyleProperty(typeof(StyleFontFamilyProperty))]
		public void SetFontFamily(StyleFontFamilyProperty property)
		{
			View.Font = UIFont.FromName(property.FontName, View.Font.PointSize);
		}
		
		[StyleProperty(typeof(StyleFontSizeProperty))]
		public void SetFontSize(StyleFontSizeProperty property)
		{
			View.Font = UIFont.FromName(View.Font.Name, property.Size);
		}
		
		[StyleProperty(typeof(StyleColorProperty))]
		public void SetFontColor(StyleColorProperty property)
		{
			View.TextColor = UIColor.FromRGBA(property.Color.R, property.Color.G, property.Color.B, property.Color.A);
		}
	}
}

