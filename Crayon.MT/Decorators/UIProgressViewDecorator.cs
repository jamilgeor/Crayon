using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIProgressView), "progress")]
	public class UIProgressViewDecorator : BaseDecorator<UIProgressView>
	{
	}
}

