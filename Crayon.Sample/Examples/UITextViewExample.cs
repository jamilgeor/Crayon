using System;
using MonoTouch.UIKit;
using Crayon.MT;

namespace Crayon.Sample
{
	public class UITextViewExample : UIViewController
	{
		UITextView _textView;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_textView = new UITextView();

			View.AddSubview(_textView);

			_textView.SetStyleId("sample-text");
			View.SetStyleClass("sample-background");
		}
	}
}

