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
			case "UIActivityIndicatorView":
				return new UIActivityIndicatorViewExample();
			case "UIButton":
				return new UIButtonExample();
			case "UICollectionView":
				return new UICollectionViewExample(new UICollectionViewFlowLayout());
			case "UIDatePicker":
				return new UIDatePickerExample();
			case "UIImageView":
				return new UIImageViewExample();
			case "UILabel":
				return new UILabelExample();
			case "UIPageControl":
				return new UIPageControlExample();
			case "UIPickerView":
				return new UIPickerViewExample();
			case "UIProgressView":
				return new UIProgressViewExample();
			case "UIScrollView":
				return new UIScrollViewExample();
			case "UISearchBar":
				return new UISearchBarExample();
			case "UIToolbar":
				return new UIToolbarExample();
			}

			return null;
		}
	}
}

