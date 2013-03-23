using System;
using MonoTouch.UIKit;

namespace Crayon.Sample
{
	public static class ExampleFactory
	{
		public static UIViewController Create(string type)
		{
			switch (type) {
			case "UIButton":
				return new UIButtonExample();
			case "UILabel":
				return new UILabelExample();
			case "UIImageView":
				return new UIImageViewExample();
			}

			return null;
		}
	}
}

