using System;
using MonoTouch.UIKit;

using Crayon;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UILabel))]
	public class UILabelDecorator : IControlDecorator
	{
		UILabel _labelView;
		
		public virtual void SetControl(object control)
		{
			_labelView = (UILabel)control;
		}

		[StyleProperty(typeof(StyleColorProperty))]
		public void SetTextColor(StyleColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			_labelView.TextColor = color;
		}

		[StylePropertyAttribute(typeof(StyleTextAlignProperty))]
		public void SetTextAlignment(StyleTextAlignProperty property)
		{
			_labelView.TextAlignment = Helpers.ConvertAlignment(property.Alignment);
		}
	}
}

