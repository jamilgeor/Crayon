using System;
using Xamarin.Forms;

namespace Crayon.Forms
{
	public static class VisualElementExtensions
	{
		public static void InitializeStyles(this VisualElement element)
		{
			StyleContext.Current.SetStyleByClass(element.ClassId, element);
			StyleContext.Current.SetStyleById(element.StyleId, element);

			element.ChildAdded += (object s, ElementEventArgs e) => {
				StyleContext.Current.SetStyleByClass(e.Element.ClassId, e.Element);
				StyleContext.Current.SetStyleById(e.Element.StyleId, e.Element);
			};
		}
	}
}

