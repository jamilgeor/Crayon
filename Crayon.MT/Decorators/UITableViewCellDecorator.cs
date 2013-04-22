using System;
using MonoTouch.UIKit;

using Crayon;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UITableViewCell))]
	public class UITableViewCellDecorator : BaseDecorator<UITableViewCell>
	{
		[StyleProperty(typeof(StyleColorProperty))]
		public void SetTextColor(StyleColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			View.TextLabel.TextColor = color;
		}

		[StyleProperty(typeof(StyleFontFamilyProperty))]
		public void SetFontFmaily(StyleFontFamilyProperty property)
		{
			var fontSize = View.TextLabel.Font.PointSize == 0 ? UIFont.SystemFontSize : View.TextLabel.Font.PointSize;

			View.TextLabel.Font = UIFont.FromName (property.FontName, fontSize);
		}

		[StyleProperty(typeof(StyleFontSizeProperty))]
		public void SetFontSize(StyleFontSizeProperty property)
		{
			View.TextLabel.Font = UIFont.FromName (View.TextLabel.Font.Name, property.Size);
		}
	}
}

