using System;
using System.Drawing;

using MonoTouch.UIKit;

using Crayon;
using System.Collections.Generic;
using System.Reflection;

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
			Media.DeviceType = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad ? DeviceType.IPad : DeviceType.IPhone;

		}

		public IList<Type> GetControlDecorators ()
		{
			var decorators = new List<Type>();
			var assembly = Assembly.GetExecutingAssembly();

			foreach(var type in assembly.GetTypes()) {
				if (type.GetInterface(typeof(IControlDecorator).Name) != null)
					decorators.Add(type);
			}

			return decorators;
		}
	}
}

