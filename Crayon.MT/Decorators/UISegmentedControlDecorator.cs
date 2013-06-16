using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UISegmentedControl), "segmented-control")]
	public class UISegmentedControlDecorator : BaseDecorator<UISegmentedControl>
	{
		[StyleProperty(typeof(StyleFontFamilyProperty))]
		public void SetFontFace(StyleFontFamilyProperty property)
		{
			var textAttributes = View.GetTitleTextAttributes(UIControlState.Normal);

			textAttributes.Font = UIFont.FromName(property.FontName, textAttributes.Font == null ? UIFont.SystemFontSize : textAttributes.Font.PointSize);
		
			if (property.Global)
				UISegmentedControl.Appearance.SetTitleTextAttributes(textAttributes, UIControlState.Normal);
			else
				View.SetTitleTextAttributes(textAttributes, UIControlState.Normal);
		}

		[StyleProperty(typeof(StyleFontSizeProperty))]
		public void SetFontSize(StyleFontSizeProperty property)
		{
			var textAttributes = View.GetTitleTextAttributes(UIControlState.Normal);

			textAttributes.Font = UIFont.FromName(textAttributes.Font == null ? Defaults.FontName : textAttributes.Font.Name, property.Size);

			View.SetTitleTextAttributes(textAttributes, UIControlState.Normal);
		}

		[StyleProperty(typeof(StyleColorProperty))]
		public void SetFontColor(StyleColorProperty property)
		{
			var textAttributes = View.GetTitleTextAttributes(UIControlState.Normal);

			textAttributes.TextColor = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			if (property.Global)
				UISegmentedControl.Appearance.SetTitleTextAttributes(textAttributes, UIControlState.Normal);
			else
				View.SetTitleTextAttributes(textAttributes, UIControlState.Normal);
		}
	}
}

