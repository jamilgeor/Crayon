using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	public static class BarItemExtensions
	{
		public static void SetStyleId (this UIBarItem view, string styleId)
		{
			StyleContext.Current.SetStyleById (styleId, view);
		}
		
		public static void SetStyleClass (this UIBarItem view, string styleClass)
		{
			StyleContext.Current.SetStyleByClass (styleClass, view);
		}
	}
}

