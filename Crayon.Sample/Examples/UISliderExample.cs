using System;
using MonoTouch.UIKit;
using Crayon.MT;

namespace Crayon.Sample
{
	public class UISliderExample : UIViewController
	{
		UISlider _slider;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_slider = new UISlider();

			View.SetStyleClass("sample-background");
			_slider.SetStyleId("sample-slider");

			View.AddSubview(_slider);
		}
	}
}

