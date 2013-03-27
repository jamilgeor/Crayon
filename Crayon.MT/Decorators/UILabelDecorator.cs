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

		[StyleProperty(typeof(StyleTextAlignProperty))]
		public void SetTextAlignment(StyleTextAlignProperty property)
		{
			_labelView.TextAlignment = Helpers.ConvertAlignment(property.Alignment);
		}

		[StyleProperty(typeof(StyleFontFamilyProperty))]
		public void SetFontFace(StyleFontFamilyProperty property)
		{
			_labelView.Font = UIFont.FromName (property.FontName, _labelView.Font.PointSize);
		}

		[StyleProperty(typeof(StyleFontSizeProperty))]
		public void SetFontSize(StyleFontSizeProperty property)
		{
			_labelView.Font = UIFont.FromName (_labelView.Font.Name, property.Size);
		}
	}
}

