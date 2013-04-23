using System;
using MonoTouch.UIKit;
using Crayon.MT;

namespace Crayon.Sample
{
	public class UISwitchExample : UIViewController
	{
		UISwitch _switch;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_switch = new UISwitch();

			View.AddSubview(_switch);

			View.SetStyleClass("sample-background");
			_switch.SetStyleId("sample-switch");
		}
	}
}

