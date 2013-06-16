using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIWebView), "web")]
	public class UIWebViewDecorator : BaseDecorator<UIWebView>
	{
	}
}

