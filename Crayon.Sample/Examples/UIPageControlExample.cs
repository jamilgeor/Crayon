using System;
using MonoTouch.UIKit;
using Crayon.MT;

namespace Crayon.Sample
{
	public class UIPageControlExample : UIViewController
	{
		UIPageControl _pageControl;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.SetStyleId("sample-page-control-background");

			_pageControl = new UIPageControl();
			_pageControl.Pages = 5;

			_pageControl.SetStyleId("sample-page-control");

			View.AddSubview(_pageControl);
		}
	}
}

