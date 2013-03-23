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
	}
}

