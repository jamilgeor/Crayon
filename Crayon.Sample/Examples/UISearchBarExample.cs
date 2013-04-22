using System;
using MonoTouch.UIKit;
using Crayon.MT;

namespace Crayon.Sample
{
	public class UISearchBarExample : UIViewController
	{
		UISearchBar _searchBar;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_searchBar = new UISearchBar();

			View.AddSubview(_searchBar);

			View.SetStyleClass("sample-background");
			_searchBar.SetStyleId("sample-search");
		}
	}
}

