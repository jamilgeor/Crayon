using System;
using System.Drawing;
using MonoTouch.UIKit;

using Crayon.MT;

namespace Crayon.Sample
{
	public class UIActionSheetExample : UIViewController
	{
		UIActionSheet _actionSheet;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var button = UIButton.FromType (UIButtonType.Custom);
			button.SetStyleId ("sample-button");
			button.SetTitle ("Show Actionsheet", UIControlState.Normal);

			View.AddSubview (button);
			View.SetStyleClass ("sample-background");

			button.TouchUpInside += (object sender, EventArgs e) => {
				_actionSheet = new UIActionSheet("Sample Action Sheet");

				_actionSheet.AddButton("First Button");
				_actionSheet.AddButton("Second Button");
				_actionSheet.AddButton("Third Button");

				_actionSheet.ShowInView(View);

				_actionSheet.SetStyleId("sample-action-sheet");
			};
		}
	}
}

