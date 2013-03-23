using System;
using MonoTouch.UIKit;

using Crayon.MT;

namespace Crayon.Sample
{
	public class UILabelExample : UIViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var label = new UILabel ();
			label.Text = "Hello, world!";
			label.SetStyleId ("sample-label");

			View.AddSubview (label);
			View.SetStyleClass ("sample-background");
		}
	}
}

