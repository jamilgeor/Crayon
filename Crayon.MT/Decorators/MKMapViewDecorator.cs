using System;
using MonoTouch.MapKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(MKMapView), "map")]
	public class MKMapViewDecorator : BaseDecorator<MKMapView>
	{
	}
}

