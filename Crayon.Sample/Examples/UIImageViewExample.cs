using System;
using MonoTouch.UIKit;

using Crayon.MT;

namespace Crayon.Sample
{
	public class UIImageViewExample : UIViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var image = new UIImageView (UIImage.FromFile ("background.jpg"));
			image.SetStyleId ("sample-image");

			View.AddSubview (image);
			View.SetStyleClass ("sample-background");
		}
	}
}

