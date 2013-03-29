using System;
using MonoTouch.UIKit;
using Crayon.MT;

namespace Crayon.Sample
{
	public class UIToolbarExample : UIViewController
	{
		UIToolbar _toolbar;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_toolbar = new UIToolbar ();
			_toolbar.SetStyleId ("sample-toolbar");

			View.AddSubview (_toolbar);
			View.SetStyleClass ("sample-background");

			var barButton = new UIBarButtonItem ("Test", UIBarButtonItemStyle.Bordered, null);
			barButton.SetStyleId ("sample-baritem");

			_toolbar.Items = new UIBarButtonItem[]{ barButton };
		}
	}
}

