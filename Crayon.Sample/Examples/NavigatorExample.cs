using System;
using MonoTouch.UIKit;

using Crayon.MT;

namespace Crayon.Sample
{
	public class NavigatorExample : UINavigationController
	{
		TableExample _table;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_table = new TableExample ();
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

