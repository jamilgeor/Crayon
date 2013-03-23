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
		
		void SetBackgroundColor(CGColor color)
		{
			var rect = color != null ? new RectangleF(0, 0, 1, 1) : _actionSheet.Layer.Bounds;
			UIGraphics.BeginImageContext (rect.Size);
			using (var context = UIGraphics.GetCurrentContext()) {
				context.SetFillColorWithColor (color);
				context.FillRect (rect);

				_actionSheet.Layer.Contents = UIGraphics.GetImageFromCurrentImageContext ().CGImage;

				UIGraphics.EndImageContext ();
			}
		}

		void SetBackgroundImage(CGImage image, float alpha)
		{
			UIGraphics.BeginImageContext (new SizeF(image.Width, image.Height));
			using (var context = UIGraphics.GetCurrentContext()) {
				context.SetAlpha(alpha);
				
				context.DrawImage(_actionSheet.Layer.Bounds, image);

				_actionSheet.Layer.Contents = UIGraphics.GetImageFromCurrentImageContext ().CGImage;
				
				UIGraphics.EndImageContext ();
			}
		}

		[StyleProperty(typeof(StyleBackgroundColorProperty))]
		public void SetBackgroundColor(StyleBackgroundColorProperty property)
		{
			var color = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);

			SetBackgroundColor (color.CGColor);
		}

		[StyleProperty(typeof(StyleBackgroundImageProperty))]
		public void SetBackgroundImage(StyleBackgroundImageProperty property)
		{
			var image = UIImage.FromFile (property.ImageUrl);

			SetBackgroundImage (image.CGImage, 1f);
		}

		[StyleProperty(typeof(StyleBackgroundOpacityProperty))]
		public void SetBackgroundOpacity(StyleBackgroundOpacityProperty property)
		{
			SetBackgroundImage (_actionSheet.Layer.Contents, property.Opacity);
		}
	}
}

