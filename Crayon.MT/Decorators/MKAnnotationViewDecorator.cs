using System;
using MonoTouch.MapKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(MKAnnotationView), "annotation")]
	public class MKAnnotationViewDecorator : BaseDecorator<MKAnnotationView>
	{
	}
}

