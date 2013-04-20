using System;
using MonoTouch.UIKit;
using Crayon.MT;
using System.Drawing;

namespace Crayon.Sample
{
	public class UIProgressViewExample : UIViewController
	{
		UIProgressView _progressView;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_progressView = new UIProgressView();

			_progressView.SetStyleId("sample-progress");
			View.SetStyleClass("sample-background");

			_progressView.Progress = 0.5f;
			
			View.AddSubview(_progressView);
		}
	}
}

