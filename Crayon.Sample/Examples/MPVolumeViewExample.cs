using System;
using MonoTouch.UIKit;
using MonoTouch.MediaPlayer;
using Crayon.MT;
using System.Drawing;

namespace Crayon.Sample
{
	public class MPVolumeViewExample : UIViewController
	{
		MPVolumeView _volumeView;
		UILabel _warningLabel;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_warningLabel = new UILabel(new RectangleF(20, 30, 280, 20));
			_warningLabel.Text = "This example will only work on device.";
			_warningLabel.Font = UIFont.FromName("GillSans", UIFont.SystemFontSize);
			_warningLabel.TextAlignment = UITextAlignment.Center;

			_volumeView = new MPVolumeView();

			_volumeView.SetStyleId("sample-volume");
			View.SetStyleClass("sample-background");

			View.AddSubview(_warningLabel);
			View.AddSubview(_volumeView);
		}
	}
}

