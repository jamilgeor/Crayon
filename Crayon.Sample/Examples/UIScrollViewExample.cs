using System;
using MonoTouch.UIKit;
using Crayon.MT;
using System.Drawing;

namespace Crayon.Sample
{
	public class UIScrollViewExample : UIViewController
	{
		UIScrollView _scrollView;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad();

			_scrollView = new UIScrollView();

			_scrollView.SetStyleId("sample-scroll-view");
			_scrollView.SetStyleClass("sample-background");

			_scrollView.ContentSize = new SizeF(1000, 1000);

			View.AddSubview(_scrollView);
		}
	}
}

