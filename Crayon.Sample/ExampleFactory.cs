using System;
using MonoTouch.UIKit;

namespace Crayon.Sample
{
	public static class ExampleFactory
	{
		public static UIViewController Create(string type)
		{
			switch (type) {
			case "UIActionSheet":
				return new UIActionSheetExample();
			case "UIButton":
				return new UIButtonExample();
			case "UIImageView":
				return new UIImageViewExample();
			case "UILabel":
				return new UILabelExample();
			case "UIActivityIndicatorView":
				return new UIActivityIndicatorViewExample();
			}

			return null;
		}
	}
}

