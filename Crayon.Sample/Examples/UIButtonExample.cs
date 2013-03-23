using System;
using MonoTouch.UIKit;
using Crayon.MT;

namespace Crayon.Sample
{
	public class UIButtonExample : UIViewController
	{
		UIButton _button;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_button = UIButton.FromType (UIButtonType.Custom);
			_button.SetStyleId ("sample-button");
			_button.SetTitle ("Hello, world!", UIControlState.Normal);

			View.AddSubview (_button);
			View.SetStyleClass ("sample-background");
		}
	}
}

