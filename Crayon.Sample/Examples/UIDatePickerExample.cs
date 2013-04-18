using System;
using MonoTouch.UIKit;
using Crayon.MT;

namespace Crayon.Sample
{
	public class UIDatePickerExample : UIViewController
	{
		UIDatePicker _datePicker;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad();

			View.SetStyleClass("sample-background");

			_datePicker = new UIDatePicker();

			_datePicker.SetStyleId("sample-date");

			View.AddSubview(_datePicker);
		}
	}
}

