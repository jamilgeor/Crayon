using System;
using MonoTouch.UIKit;
using Crayon.MT;
using MonoTouch.Foundation;

namespace Crayon.Sample
{
	public class UIWebViewExample : UIViewController
	{
		UIWebView _webView;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_webView = new UIWebView();

			_webView.SetStyleId("sample-web");
			View.SetStyleClass("sample-background");

			View.AddSubview(_webView);

			_webView.LoadRequest(new NSUrlRequest(new NSUrl("http://www.google.com")));
		}
	}
}

