using System;
using MonoTouch.UIKit;

using Crayon;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UITableViewCell))]
	public class UITableViewCellDecorator : IControlDecorator
	{
		UITableViewCell _cellView;

		public virtual void SetControl(object control)
		{
			_cellView = (UITableViewCell)control;
		}

		[StyleProperty(typeof(StyleColorProperty))]
		public void SetTextColor(StyleColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			_cellView.TextLabel.TextColor = color;
		}

		[StyleProperty(typeof(StyleFontFamilyProperty))]
		public void SetFontFmaily(StyleFontFamilyProperty property)
		{
			//By default text label font size is set to 0 which causes rendering issues
			const float defaultFontSize = 18.0f;
			var fontSize = _cellView.TextLabel.Font.PointSize == 0 ? defaultFontSize : _cellView.TextLabel.Font.PointSize;

			_cellView.TextLabel.Font = UIFont.FromName (property.FontName, fontSize);
		}

		[StyleProperty(typeof(StyleFontSizeProperty))]
		public void SetFontSize(StyleFontSizeProperty property)
		{
			_cellView.TextLabel.Font = UIFont.FromName (_cellView.TextLabel.Font.Name, property.Size);
		}
	}
}

