using System;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using Crayon.MT;

namespace Crayon.Sample
{
	public class MKMapViewExample : UIViewController
	{
		MKMapView _mapView;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_mapView = new MKMapView();

			_mapView.SetStyleId("sample-map");
			View.SetStyleClass("sample-background");
			
			View.AddSubview(_mapView);
		}
	}
}

