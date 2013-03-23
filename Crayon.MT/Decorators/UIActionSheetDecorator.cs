using System;
using System.Linq;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

using Crayon;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIActionSheet))]
	public class UIActionSheetDecorator : IControlDecorator
	{
		UIActionSheet _actionSheet;

		public void SetControl(object control)
		{
			_actionSheet = (UIActionSheet)control;
		}
		
		void SetBackground(CGColor color, float alpha)
		{
			var rect = color != null ? new RectangleF(0, 0, 1, 1) : _actionSheet.Layer.Bounds;
			UIGraphics.BeginImageContext (rect.Size);
			using (var context = UIGraphics.GetCurrentContext()) {
				context.SetAlpha(alpha);

				if (color != null) {
					context.SetFillColorWithColor (color);
					context.FillRect (rect);
				} else {
					context.DrawImage(_actionSheet.Layer.Bounds, _actionSheet.Layer.Contents);
				}

				_actionSheet.Layer.Contents = UIGraphics.GetImageFromCurrentImageContext ().CGImage;

				UIGraphics.EndImageContext ();
			}
		}

		[StyleProperty(typeof(StyleBackgroundColorProperty))]
		public void SetBackgroundColor(StyleBackgroundColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			SetBackground (color.CGColor, 1f);
		}

		[StyleProperty(typeof(StyleBackgroundOpacityProperty))]
		public void SetBackgroundOpacity(StyleBackgroundOpacityProperty property)
		{
			SetBackground (null, property.Opacity);
		}
	}
}

