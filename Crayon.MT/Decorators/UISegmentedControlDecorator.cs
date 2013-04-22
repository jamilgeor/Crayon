using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UISegmentedControl))]
	public class UISegmentedControlDecorator : BaseDecorator<UISegmentedControl>
	{
		[StyleProperty(typeof(StyleFontFamilyProperty))]
		public void SetFontFace(StyleFontFamilyProperty property)
		{
			var textAttributes = View.GetTitleTextAttributes(UIControlState.Normal);

			textAttributes.Font = UIFont.FromName(property.FontName, 10f);//property.FontName, textAttributes.Font == null ? UIFont.SystemFontSize : textAttributes.Font.PointSize);
		
			View.SetTitleTextAttributes(textAttributes, UIControlState.Normal);
		}

		[StyleProperty(typeof(StyleFontSizeProperty))]
		public void SetFontSize(StyleFontSizeProperty property)
		{
			var textAttributes = View.GetTitleTextAttributes(UIControlState.Normal);

			textAttributes.Font = UIFont.FromName(textAttributes.Font == null ? Defaults.FontName : textAttributes.Font.Name, property.Size);

			View.SetTitleTextAttributes(textAttributes, UIControlState.Normal);
		}
	}
}

