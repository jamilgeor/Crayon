using System;
using MonoTouch.UIKit;
using Crayon.MT;

namespace Crayon.Sample
{
	public class UITabBarExample : UITabBarController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var tab1Controller = new UIViewController();
			var tab2Controller = new UIViewController();

			tab1Controller.Title = "Tab 1";
			tab2Controller.Title = "Tab 2";

			tab1Controller.TabBarItem.SetStyleClass("sample-tabbar-item");
			tab2Controller.TabBarItem.SetStyleClass("sample-tabbar-item");

			AddChildViewController(tab1Controller);
			AddChildViewController(tab2Controller);

			TabBar.SetStyleId("sample-tabbar");
			tab1Controller.TabBarItem.SetStyleClass("sample-tab");
			tab2Controller.TabBarItem.SetStyleClass("sample-tab");

			View.SetStyleClass("sample-background");
		}
	}
}

