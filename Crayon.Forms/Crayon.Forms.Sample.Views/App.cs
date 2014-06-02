using System;
using Xamarin.Forms;

namespace Crayon.Forms.Sample.Views
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new ContentPage { 
				Content = new Label {
					Text = "Hello, Forms !",
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
				},
				StyleId = "sample-page"
			};
		}
	}
}

