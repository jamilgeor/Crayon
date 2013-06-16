using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UITabBarItem), "tab-bar-item")]
	public class UITabBarItemDecorator : IControlDecorator
	{
		UITabBarItem View { get; set; }

		public void SetControl (object control)
		{
			View = (UITabBarItem)control;
		}

		void SetTextAttributes(UITextAttributes textAttributes, StyleProperty property)
		{
			if (property.Global)
				return;

			View.SetTitleTextAttributes(textAttributes, UIControlState.Normal);
		}

		[StyleProperty(typeof(StyleFontFamilyProperty))]
		public void SetFontFace(StyleFontFamilyProperty property)
		{
			var textAttributes = View.GetTitleTextAttributes(UIControlState.Normal);
			
			textAttributes.Font = UIFont.FromName(property.FontName, textAttributes.Font == null ? UIFont.SystemFontSize : textAttributes.Font.PointSize);

			SetTextAttributes (textAttributes, property);
		}
		
		[StyleProperty(typeof(StyleFontSizeProperty))]
		public void SetFontSize(StyleFontSizeProperty property)
		{
			var textAttributes = View.GetTitleTextAttributes(UIControlState.Normal);
			
			textAttributes.Font = UIFont.FromName(textAttributes.Font == null ? Defaults.FontName : textAttributes.Font.Name, property.Size);

			SetTextAttributes (textAttributes, property);
		}
		
		[StyleProperty(typeof(StyleColorProperty))]
		public void SetFontColor(StyleColorProperty property)
		{
			var textAttributes = View.GetTitleTextAttributes(UIControlState.Normal);
			
			textAttributes.TextColor = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			SetTextAttributes (textAttributes, property);
		}
	}
}

