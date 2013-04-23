using System;
using MonoTouch.UIKit;
using Crayon.MT;

namespace Crayon.Sample
{
	public class UIStepperExample : UIViewController
	{
		UIStepper _stepper;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_stepper = new UIStepper();

			View.AddSubview(_stepper);

			View.SetStyleClass("sample-background");
			_stepper.SetStyleId("sample-stepper");
		}
	}
}

