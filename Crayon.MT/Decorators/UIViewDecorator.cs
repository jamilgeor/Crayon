using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

using Crayon;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIView))]
	public class UIViewDecorator : IControlDecorator
	{
		UIView _view;

		public virtual void SetControl(object control)
		{
			_view = (UIView)control;
		}

		[StyleProperty(typeof(StyleWidthProperty))]
		public void SetWidth(StyleWidthProperty property)
		{
			_view.Frame = new RectangleF(_view.Frame.X, _view.Frame.Y, property.Width, _view.Frame.Height);
		}

		[StyleProperty(typeof(StyleHeightProperty))]
		public void SetHeight(StyleHeightProperty property)
		{
			_view.Frame = new RectangleF(_view.Frame.X, _view.Frame.Y, _view.Frame.Width, property.Height);
		}

		[StyleProperty(typeof(StyleOpacityProperty))]
		public void SetOpacity(StyleOpacityProperty property)
		{
			_view.Alpha = property.Opacity;
		}

		[StyleProperty(typeof(StyleTopProperty))]
		public void SetTop(StyleTopProperty property)
		{
			_view.Frame = new RectangleF(_view.Frame.X, property.Top, _view.Frame.Width, _view.Frame.Height);
		}

		[StyleProperty(typeof(StyleLeftProperty))]
		public void SetLeft(StyleLeftProperty property)
		{
			_view.Frame = new RectangleF(property.Left, _view.Frame.Y, _view.Frame.Width, _view.Frame.Height);
		}

		[StyleProperty(typeof(StyleBackgroundColorProperty))]
		public void SetBackgroundColor(StyleColorProperty property)
		{
			_view.BackgroundColor = UIColor.FromRGBA (property.Color.R, property.Color.G, property.Color.B, property.Color.A);
		}

		[StyleProperty(typeof(StyleBackgroundImageProperty))]
		public void SetBackgroundImage(StyleBackgroundImageProperty property)
		{
			_view.BackgroundColor = UIColor.FromPatternImage (UIImage.FromFile(property.ImageUrl));
		}

		[StyleProperty(typeof(StyleBorderColorProperty))]
		public void SetBorderColor(StyleBorderColorProperty property)
		{
			_view.Layer.BorderColor = new CGColor(property.Color.R, property.Color.G, property.Color.B, property.Color.A);
		}

		[StyleProperty(typeof(StyleBorderWidthProperty))]
		public void SetBorderWidth(StyleBorderWidthProperty property)
		{
			_view.Layer.BorderWidth = property.Width;
		}
	}
}

