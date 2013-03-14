using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	public static class UIViewExtensions
	{
		public static void SetStyleId (this UIView view, string styleId)
		{
			StyleContext.Current.SetStyleById (styleId, view);
		}

		public static void SetStyleClass (this UIView view, string styleClass)
		{
			StyleContext.Current.SetStyleByClass (styleClass, view);
		}
	}
}

