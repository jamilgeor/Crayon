using System;
using MonoTouch.UIKit;

using Crayon.MT;

namespace Crayon.Sample
{
	public class ExampleNavigationController : UINavigationController
	{
		UITableViewExample _table;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			NavigationBar.SetStyleId("sample-navigation");
			View.SetStyleId ("sample-navigator");

			_table = new UITableViewExample ();
			_table.View.SetStyleId ("sample-table");

			PushViewController (_table, false);

			_table.OnRowSelected += (object sender, RowSelectedEventArgs e) => {
				var controller = ExampleFactory.Create(e.Value);

				if (controller != null)
					PushViewController(controller, true);
			};
		}
	}
}

