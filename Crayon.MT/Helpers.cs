using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	public static class Helpers
	{
		public static UITextAlignment ConvertAlignment(Alignment alignment)
		{
			switch (alignment) {
			case Alignment.Center:
				return UITextAlignment.Center;
			case Alignment.Right:
				return UITextAlignment.Right;
			default:
				return UITextAlignment.Left;
			}
		}
	}
}

