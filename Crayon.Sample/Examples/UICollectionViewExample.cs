using System;
using System.Collections.Generic;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;

using Crayon.MT;

namespace Crayon.Sample
{
	public class UICollectionViewExample : UICollectionViewController
	{
		readonly static NSString CellId = new NSString("ExampleCellId");
		readonly static NSString HeaderId = new NSString ("ExampleHeaderId");

		List<CollectionItem> _items;

		public UICollectionViewExample (UICollectionViewLayout layout) : base(layout)
		{
			_items = new List<CollectionItem>
			{
				new CollectionItem { Name = "Example 1" },
				new CollectionItem { Name = "Example 2" }
			};

			CollectionView.Delegate = new ExampleLayoutDelegate();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			CollectionView.SetStyleClass ("sample-background");
			CollectionView.SetStyleId ("sample-collection");

			CollectionView.RegisterClassForCell (typeof(ExampleCollectionItemCell), CellId);
		}

		public override int NumberOfSections (UICollectionView collectionView)
		{
			return 1;
		}

		public override int GetItemsCount (UICollectionView collectionView, int section)
		{
			return _items.Count;
		}

		public override bool ShouldShowMenu (UICollectionView collectionView, NSIndexPath indexPath)
		{
			return true;
		}

		public override bool CanPerform (MonoTouch.ObjCRuntime.Selector action, NSObject withSender)
		{
			return true;
		}

		public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
			var item = _items [indexPath.Row];
			var cell = (ExampleCollectionItemCell) collectionView.DequeueReusableCell (CellId, indexPath);

			cell.Title = item.Name;

			return cell;
		}

		class CollectionItem 
		{
			public string Name { get; set; }
		}

		class ExampleCollectionItemCell : UICollectionViewCell
		{
			UILabel _label;
			UIImageView _imageView;

			public string Title
			{
				get { return _label.Text; }
				set { _label.Text = value; }
			}

			[Export ("initWithFrame:")]
			public ExampleCollectionItemCell(RectangleF frame) : base(frame)
			{
				_label = new UILabel();
				_imageView = new UIImageView(UIImage.FromFile("person.jpg"));

				_label.SetStyleClass("sample-cell-label");
				_imageView.SetStyleClass("sample-cell-image");

				ContentView.AddSubview(_imageView);
				ContentView.AddSubview(_label);
			}
		}

		class ExampleLayoutDelegate : UICollectionViewDelegateFlowLayout
		{
			public override SizeF GetSizeForItem (UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
			{
				return new SizeF(80, 130);
			}
		}
	}
}

