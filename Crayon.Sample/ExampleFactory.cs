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
				return new ButtonExample();
			case "UILabel":
				return new LabelExample();
			case "UIImageView":
				return new ImageExample();
			}

			return null;
		}
	}
}

