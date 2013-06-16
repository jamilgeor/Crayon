using System;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIActivityIndicatorView), "activity-indicator")]
	public class UIActivityIndicatorViewDecorator : BaseDecorator<UIActivityIndicatorView>
	{
		[StyleProperty(typeof(StyleWidthProperty))]
		public override void SetWidth(StyleWidthProperty property)
		{
			if (property.Global)
				return;

			View.Transform = CGAffineTransform.MakeScale (property.Width, View.Transform.yy);
		}

		[StyleProperty(typeof(StyleHeightProperty))]
		public override void SetHeight(StyleHeightProperty property)
		{
			if (property.Global)
				return;

			View.Transform = CGAffineTransform.MakeScale (View.Transform.xx, property.Height);
		}
	}
}

