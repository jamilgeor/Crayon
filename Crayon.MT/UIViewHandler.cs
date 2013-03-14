using System;
using System.Drawing;
using MonoTouch.UIKit;

using Crayon;

namespace Crayon.MT
{
	[ControlHandler(typeof(UIView))]
	public class UIViewHandler : IControlHandler
	{
		UIView _view;

		public void SetControl(object control)
		{
			_view = (UIView)control;
		}

		[StylePropertyHandlerAttribute(typeof(StyleWidthProperty))]
		public void SetWidthProperty(StyleWidthProperty property)
		{
			_view.Frame = new RectangleF(_view.Frame.X, _view.Frame.Y, property.Width, _view.Frame.Height);
		}

		[StylePropertyHandlerAttribute(typeof(StyleHeightProperty))]
		public void SetWidthProperty(StyleHeightProperty property)
		{
			_view.Frame = new RectangleF(_view.Frame.X, _view.Frame.Y, _view.Frame.Width, property.Height);
		}
	}
}

