using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIScrollView), "scroll")]
	public class UIScrollViewDecorator : BaseDecorator<UIScrollView>
	{
	}
}

