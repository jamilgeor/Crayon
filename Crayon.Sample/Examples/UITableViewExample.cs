using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

using Crayon.MT;
using System.Drawing;

namespace Crayon.Sample
{
	public class UITableViewExample : UITableViewController
	{
		UIRefreshControl _refreshControl;
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

			AddHeader();
			AddRefreshControl();
		
		}

		void AddHeader()
		{
			var header = new UITableViewHeaderFooterView();
			
			header.TextLabel.Text = "Crayon Examples";
			header.SetStyleId("sample-table-header");
			
			TableView.TableHeaderView = header;
		}

		void AddRefreshControl()
		{
			_refreshControl = new UIRefreshControl();
			
			_refreshControl.SetStyleId("sample-refresh");
			
			_refreshControl.ValueChanged += (o, e) => {
				_refreshControl.EndRefreshing();
			};

			TableView.AddSubview(_refreshControl);
		}
	}

	public class TableSampleDelegate : UITableViewDelegate
	{
		public event EventHandler<RowSelectedEventArgs> OnRowSelected;

		/*public override UIView GetViewForHeader (UITableView tableView, int section)
		{
			var header = new UITableViewHeaderFooterView();

			header.TextLabel.Text = "Crayon Examples";
			header.DetailTextLabel.Text = "Detailed text";
			header.SetStyleId("sample-table-header");

			return header;
		}*/

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
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
				"UIButton",
				"UICollectionView",
				"UIDatePicker",
				"UIImageView",
				"UILabel",
				"UIPageControl",
				"UIPickerView",
				"UIProgressView",
				"UIScrollView",
				"UISearchBar",
				"UISegmentedControl",
				"UISlider",
				"UIStepper",
				"UISwitch",
				"UITabBar",
				"UITableViewHeaderFooterView",
				"UITextField",
				"UITextView",
				"UIToolbar",
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

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var id = string.Format ("cell{0}", indexPath.Row);
			var cell = tableView.DequeueReusableCell (id);

			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, id);

			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			cell.TextLabel.Text = Rows [indexPath.Row];
			cell.SetStyleClass ("sample-table-cell");

			return cell;
		}
	}
}

