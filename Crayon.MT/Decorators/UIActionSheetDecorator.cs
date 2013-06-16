using System;
using System.Linq;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

using Crayon;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIActionSheet), "action-sheet")]
	public class UIActionSheetDecorator : BaseDecorator<UIActionSheet>
	{
		void SetBackgroundColor(CGColor color)
		{
			var rect = color != null ? new RectangleF(0, 0, 1, 1) : View.Layer.Bounds;
			UIGraphics.BeginImageContext (rect.Size);
			using (var context = UIGraphics.GetCurrentContext()) {
				context.SetFillColorWithColor (color);
				context.FillRect (rect);

				View.Layer.Contents = UIGraphics.GetImageFromCurrentImageContext ().CGImage;

				UIGraphics.EndImageContext ();
			}
		}

		void SetBackgroundImage(CGImage image, float alpha)
		{
			UIGraphics.BeginImageContext (new SizeF(image.Width, image.Height));
			using (var context = UIGraphics.GetCurrentContext()) {
				context.SetAlpha(alpha);
				
				context.DrawImage(View.Layer.Bounds, image);

				View.Layer.Contents = UIGraphics.GetImageFromCurrentImageContext ().CGImage;
				
				UIGraphics.EndImageContext ();
			}
		}

		[StyleProperty(typeof(StyleBackgroundColorProperty))]
		public override void SetBackgroundColor(StyleBackgroundColorProperty property)
		{
			if (property.Global)
				return;

			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			SetBackgroundColor (color.CGColor);
		}

		[StyleProperty(typeof(StyleBackgroundImageProperty))]
		public override void SetBackgroundImage(StyleBackgroundImageProperty property)
		{
			if (property.Global)
				return;

			var image = UIImage.FromFile (property.ImageUrl);

			SetBackgroundImage (image.CGImage, 1f);
		}

		[StyleProperty(typeof(StyleBackgroundOpacityProperty))]
		public void SetBackgroundOpacity(StyleBackgroundOpacityProperty property)
		{
			if (property.Global)
				return;

			SetBackgroundImage (View.Layer.Contents, property.Opacity);
		}
	}
}

