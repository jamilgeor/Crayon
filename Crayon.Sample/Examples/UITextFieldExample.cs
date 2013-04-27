using System;
using MonoTouch.UIKit;
using Crayon.MT;

namespace Crayon.Sample
{
	public class UITextFieldExample : UIViewController
	{
		UITextField _textField;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_textField = new UITextField();
			_textField.Placeholder = "Sample Placeholder";

			View.AddSubview(_textField);

			_textField.SetStyleId("sample-textfield");
			View.SetStyleClass("sample-background");
		}
	}
}

