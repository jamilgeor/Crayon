using System;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using Crayon.MT;
using MonoTouch.CoreLocation;
using MonoTouch.Foundation;

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

			AddAnnotation();
		}

		void AddAnnotation()
		{
			_mapView.GetViewForAnnotation = GetViewForAnnotation;

			var annotation = new ExampleAnnotation
			{
				Coordinate = new CLLocationCoordinate2D(37.81, -122.477989) 
			};

			annotation.SetTitle("Example Annotation");

			_mapView.AddAnnotation(annotation);
		}

		MKAnnotationView GetViewForAnnotation (MKMapView mapView, NSObject annotation)
		{
			var annotationView = new MKAnnotationView(annotation, "ExampleAnnotation");

			annotationView.CanShowCallout = true;

			annotationView.SetStyleId("sample-annotation");

			return annotationView;
		}

		class ExampleAnnotation : MKAnnotation
		{
			string _title;

			public override string Title { get { return _title; } }
			public override CLLocationCoordinate2D Coordinate { get; set; }

			public void SetTitle(string title)
			{
				_title = title;
			}
		}
	}
}

