using System;
using System.Linq;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

using Crayon;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIActionSheet))]
	public class UIActionSheetDecorator : BaseDecorator
	{
		UIActionSheet View { get { return (UIActionSheet)Control; } }
		
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
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			SetBackgroundColor (color.CGColor);
		}

		[StyleProperty(typeof(StyleBackgroundImageProperty))]
		public override void SetBackgroundImage(StyleBackgroundImageProperty property)
		{
			var image = UIImage.FromFile (property.ImageUrl);

			SetBackgroundImage (image.CGImage, 1f);
		}

		[StyleProperty(typeof(StyleBackgroundOpacityProperty))]
		public void SetBackgroundOpacity(StyleBackgroundOpacityProperty property)
		{
			SetBackgroundImage (View.Layer.Contents, property.Opacity);
		}
	}
}

