using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UITabBarItem))]
	public class UITabBarItemDecorator : IControlDecorator
	{
		UITabBarItem View { get; set; }

		public void SetControl (object control)
		{
			View = (UITabBarItem)control;
		}
	}
}

