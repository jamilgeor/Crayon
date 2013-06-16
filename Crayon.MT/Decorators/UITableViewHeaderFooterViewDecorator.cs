using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UITableViewHeaderFooterView), "table-header-footer")]
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
			if (property.Global)
				return;

			InitializeBackground();
			View.BackgroundView.BackgroundColor = UIColor.FromRGBA(property.Color.R, property.Color.G, property.Color.B, property.Color.A);
		}

		[StyleProperty(typeof(StyleBackgroundImageProperty))]
		public override void SetBackgroundImage (StyleBackgroundImageProperty property)
		{
			if (property.Global)
				return;

			InitializeBackground();
			View.BackgroundColor = UIColor.FromPatternImage(new UIImage(property.ImageUrl));
		}

		[StyleProperty(typeof(StyleFontFamilyProperty))]
		public void SetFontFamily(StyleFontFamilyProperty property)
		{
			if (property.Global)
				return;

			View.TextLabel.Font = UIFont.FromName(property.FontName, View.TextLabel.Font.PointSize == 0 ? UIFont.SystemFontSize : View.TextLabel.Font.PointSize);
			View.DetailTextLabel.Font = UIFont.FromName(property.FontName, View.DetailTextLabel.Font.PointSize == 0 ? UIFont.SystemFontSize : View.DetailTextLabel.Font.PointSize);
		}

		[StyleProperty(typeof(StyleColorProperty))]
		public void SetFontColor(StyleColorProperty property)
		{
			if (property.Global)
				return;

			View.TextLabel.TextColor = UIColor.FromRGBA(property.Color.R, property.Color.G, property.Color.B, property.Color.A);
			View.DetailTextLabel.TextColor = UIColor.FromRGBA(property.Color.R, property.Color.G, property.Color.B, property.Color.A);
		}

		[StyleProperty(typeof(StyleFontSizeProperty))]
		public void SetFontSize(StyleFontSizeProperty property)
		{
			if (property.Global)
				return;

			View.TextLabel.Font = UIFont.FromName(View.TextLabel.Font.Name, property.Size);
			View.DetailTextLabel.Font = UIFont.FromName(View.DetailTextLabel.Font.Name, property.Size);
		}
	}
}

