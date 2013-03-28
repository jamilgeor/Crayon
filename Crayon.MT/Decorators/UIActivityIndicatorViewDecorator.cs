using System;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIActivityIndicatorView))]
	public class UIActivityIndicatorViewDecorator : BaseDecorator
	{
		UIActivityIndicatorView View { get { return (UIActivityIndicatorView)Control; } }

		[StyleProperty(typeof(StyleWidthProperty))]
		public override void SetWidth(StyleWidthProperty property)
		{
			View.Transform = CGAffineTransform.MakeScale (property.Width, View.Transform.yy);
		}

		[StyleProperty(typeof(StyleHeightProperty))]
		public override void SetHeight(StyleHeightProperty property)
		{
			View.Transform = CGAffineTransform.MakeScale (View.Transform.xx, property.Height);
		}
	}
}

