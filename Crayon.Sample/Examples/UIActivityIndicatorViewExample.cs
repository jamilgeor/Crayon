using System;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

using Crayon.MT;

namespace Crayon.Sample
{
	public class UIActivityIndicatorViewExample : UIViewController
	{
		UIActivityIndicatorView _activityIndicator;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_activityIndicator = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.Gray);

			View.AddSubview (_activityIndicator);

			_activityIndicator.SetStyleId ("sample-activity-indicator");

			_activityIndicator.StartAnimating ();



			View.SetStyleClass ("sample-background");
		}
	}
}

