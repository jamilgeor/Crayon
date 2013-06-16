using System;
using MonoTouch.UIKit;
using Crayon;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIImageView), "image")]
	public class UIImageViewDecorator : BaseDecorator<UIImageView>
	{
	}
}

