using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UITableViewHeaderFooterView))]
	public class UITableViewHeaderFooterViewDecorator : BaseDecorator<UITableViewHeaderFooterView>
	{
		void InitializeBackground()
		{
			if (View.BackgroundView == null)
				View.BackgroundView = new UIView(View.Frame);
		}

		[StyleProperty(typeof(StyleBackgroundColorProperty))]
		public override void SetBackgroundColor (StyleBackgroundColorProperty property)
		{
			InitializeBackground();
			View.BackgroundView.BackgroundColor = UIColor.FromRGBA(property.Color.R, property.Color.G, property.Color.B, property.Color.A);
		}

		[StyleProperty(typeof(StyleBackgroundImageProperty))]
		public override void SetBackgroundImage (StyleBackgroundImageProperty property)
		{
			InitializeBackground();
			View.BackgroundColor = UIColor.FromPatternImage(new UIImage(property.ImageUrl));
		}

		[StyleProperty(typeof(StyleFontFamilyProperty))]
		public void SetFontFamily(StyleFontFamilyProperty property)
		{
			View.TextLabel.Font = UIFont.FromName(property.FontName, View.TextLabel.Font.PointSize == 0 ? UIFont.SystemFontSize : View.TextLabel.Font.PointSize);
			View.DetailTextLabel.Font = UIFont.FromName(property.FontName, View.DetailTextLabel.Font.PointSize == 0 ? UIFont.SystemFontSize : View.DetailTextLabel.Font.PointSize);
		}

		[StyleProperty(typeof(StyleColorProperty))]
		public void SetFontColor(StyleColorProperty property)
		{
			View.TextLabel.TextColor = UIColor.FromRGBA(property.Color.R, property.Color.G, property.Color.B, property.Color.A);
			View.DetailTextLabel.TextColor = UIColor.FromRGBA(property.Color.R, property.Color.G, property.Color.B, property.Color.A);
		}

		[StyleProperty(typeof(StyleFontSizeProperty))]
		public void SetFontSize(StyleFontSizeProperty property)
		{
			View.TextLabel.Font = UIFont.FromName(View.TextLabel.Font.Name, property.Size);
			View.DetailTextLabel.Font = UIFont.FromName(View.DetailTextLabel.Font.Name, property.Size);
		}
	}
}

