using System;
using MonoTouch.UIKit;
using Crayon.MT;

namespace Crayon.Sample
{
	public class UISegmentedControlExample : UIViewController
	{
		UISegmentedControl _segmentedControl;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_segmentedControl = new UISegmentedControl();
			_segmentedControl.InsertSegment("Segment 1", 0, true);
			_segmentedControl.InsertSegment("Segment 2", 1, true);

			View.AddSubview(_segmentedControl);

			View.SetStyleClass("sample-background");
			_segmentedControl.SetStyleId("sample-segmented");
		}
	}
}

