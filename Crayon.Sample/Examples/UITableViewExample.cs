using System;
using System.Collections.Generic;

using MonoTouch.UIKit;

namespace Crayon.Sample
{
	public class UITableViewExample : UITableViewController
	{
		public event EventHandler<RowSelectedEventArgs> OnRowSelected;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			TableView.Source = new TableSampleSource ();

			var sampleDelegate = new TableSampleDelegate();

			sampleDelegate.OnRowSelected += (object sender, RowSelectedEventArgs e) => {
				if (OnRowSelected != null)
					OnRowSelected(this, e);
			};

			TableView.Delegate = sampleDelegate;
		}
	}

	public class TableSampleDelegate : UITableViewDelegate
	{
		public event EventHandler<RowSelectedEventArgs> OnRowSelected;

		public override void RowSelected (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var row = ((TableSampleSource)tableView.Source).Rows[indexPath.Row];

			if (OnRowSelected != null)
				OnRowSelected (this, new RowSelectedEventArgs{ Value = row });
		}
	}

	public class RowSelectedEventArgs : EventArgs
	{
		public string Value { get; set; }
	}

	public class TableSampleSource : UITableViewSource
	{
		public List<string> Rows { get; private set; }

		public TableSampleSource() : base()
		{
			Rows = new List<string>
			{
				"UIActionSheet",
				"UIActivityIndicatorView",
				"UIBarButtonItem",
				"UIButton",
				"UICollectionView",
				"UICollectionViewCell",
				"UIDatePicker",
				"UIImageView",
				"UILabel",
				"UINavigationBar",
				"UIPageControl",
				"UIPickerView",
				"UIProgressView",
				"UIRefreshControl",
				"UIScrollView",
				"UISearchBar",
				"UISegmentedControl",
				"UISlider",
				"UIStepper",
				"UISwitch",
				"UITabBar",
				"UITabBarItem",
				"UITableView",
				"UITableViewCell",
				"UITableViewHeaderFooterView",
				"UITextField",
				"UITextView",
				"UIToolbar",
				"UIView",
				"UIWebView",
				"MKAnnotationView",
				"MKMapView",
				"MPVolumeView"
			};
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return Rows.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var id = string.Format ("cell{0}", indexPath.Row);
			var cell = tableView.DequeueReusableCell (id);

			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, id);

			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			cell.TextLabel.Text = Rows [indexPath.Row];

			return cell;
		}
	}
}

