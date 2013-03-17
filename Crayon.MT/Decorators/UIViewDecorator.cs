using System;
using System.Drawing;
using MonoTouch.UIKit;

using Crayon;

namespace Crayon.MT
{
	[ControlHandler(typeof(UIView))]
	public class UIViewDecorator : IControlDecorator
	{
		UIView _view;

		public virtual void SetControl(object control)
		{
			_view = (UIView)control;
		}

		[StylePropertyHandlerAttribute(typeof(StyleWidthProperty))]
		public void SetWidth(StyleWidthProperty property)
		{
			_view.Frame = new RectangleF(_view.Frame.X, _view.Frame.Y, property.Width, _view.Frame.Height);
		}

		[StylePropertyHandlerAttribute(typeof(StyleHeightProperty))]
		public void SetHeight(StyleHeightProperty property)
		{
			_view.Frame = new RectangleF(_view.Frame.X, _view.Frame.Y, _view.Frame.Width, property.Height);
		}

		[StylePropertyHandlerAttribute(typeof(StyleOpacityProperty))]
		public void SetOpacity(StyleOpacityProperty property)
		{
			_view.Alpha = property.Opacity;
		}

		[StylePropertyHandlerAttribute(typeof(StyleTopProperty))]
		public void SetTop(StyleTopProperty property)
		{
			_view.Frame = new RectangleF(_view.Frame.X, property.Top, _view.Frame.Width, _view.Frame.Height);
		}

		[StylePropertyHandlerAttribute(typeof(StyleLeftProperty))]
		public void SetLeft(StyleLeftProperty property)
		{
			_view.Frame = new RectangleF(property.Left, _view.Frame.Y, _view.Frame.Width, _view.Frame.Height);
		}
	}
}

