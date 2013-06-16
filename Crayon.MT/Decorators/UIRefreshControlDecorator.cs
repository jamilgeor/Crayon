using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIRefreshControl), "refresh-control")]
	public class UIRefreshControlDecorator : BaseDecorator<UIRefreshControl>
	{
	}
}

