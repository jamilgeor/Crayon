using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

namespace Crayon.MT
{
	public class BaseDecorator : IControlDecorator
	{
		protected object Control { get; set; }
		UIView View { get { return (UIView)Control; } } 

		public void SetControl(object control)
		{
			Control = control;
		}

		[StyleProperty(typeof(StyleWidthProperty))]
		public virtual void SetWidth(StyleWidthProperty property)
		{
			View.Frame = new RectangleF(View.Frame.X, View.Frame.Y, property.Width, View.Frame.Height);
		}
		
		[StyleProperty(typeof(StyleHeightProperty))]
		public virtual void SetHeight(StyleHeightProperty property)
		{
			View.Frame = new RectangleF(View.Frame.X, View.Frame.Y, View.Frame.Width, property.Height);
		}
		
		[StyleProperty(typeof(StyleOpacityProperty))]
		public virtual void SetOpacity(StyleOpacityProperty property)
		{
			View.Alpha = property.Opacity;
		}
		
		[StyleProperty(typeof(StyleTopProperty))]
		public virtual void SetTop(StyleTopProperty property)
		{
			View.Frame = new RectangleF(View.Frame.X, property.Top, View.Frame.Width, View.Frame.Height);
		}
		
		[StyleProperty(typeof(StyleLeftProperty))]
		public virtual void SetLeft(StyleLeftProperty property)
		{
			View.Frame = new RectangleF(property.Left, View.Frame.Y, View.Frame.Width, View.Frame.Height);
		}
		
		[StyleProperty(typeof(StyleBackgroundColorProperty))]
		public virtual void SetBackgroundColor(StyleBackgroundColorProperty property)
		{
			View.BackgroundColor = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);
		}
		
		[StyleProperty(typeof(StyleBackgroundImageProperty))]
		public virtual void SetBackgroundImage(StyleBackgroundImageProperty property)
		{
			View.BackgroundColor = UIColor.FromPatternImage (UIImage.FromFile(property.ImageUrl));
		}
		
		[StyleProperty(typeof(StyleBorderColorProperty))]
		public virtual void SetBorderColor(StyleBorderColorProperty property)
		{
			View.Layer.BorderColor = new CGColor(property.Color.R, property.Color.G, property.Color.B, property.Color.A);
		}
		
		[StyleProperty(typeof(StyleBorderWidthProperty))]
		public virtual void SetBorderWidth(StyleBorderWidthProperty property)
		{
			View.Layer.BorderWidth = property.Width;
		}
		
		
		[StyleProperty(typeof(StyleBorderRadiusProperty))]
		public virtual void SetRadius(StyleBorderRadiusProperty property)
		{
			View.Layer.CornerRadius = property.Radius;
		}
	}
}

