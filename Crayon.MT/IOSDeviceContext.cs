using System;
using System.Drawing;

using MonoTouch.UIKit;

using Crayon;

namespace Crayon.MT
{
	public class IOSDeviceContext : IDeviceContext
	{
		public Media Media { get; private set; }

		public IOSDeviceContext()
		{
			Media = new Media ();
			Media.Resolution = UIScreen.MainScreen.Bounds.Size;
			Media.IsRetina = UIScreen.MainScreen.Scale > 1.0;

			//Need to add device detection.
			Media.DeviceType = UIUserInterfaceIdiom.Pad ? DeviceType.IPad : DeviceType.IPhone;

		}
	}
}

