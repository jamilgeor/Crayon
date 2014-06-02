using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using Xamarin.Forms;
using Crayon;
#if IOS
using MonoTouch.UIKit;
#endif

namespace Crayon.Forms
{
	public class FormsContext : IDeviceContext
	{
		public Media Media { get; private set; }

		public FormsContext()
		{
			Media = new Media ();
			#if IOS
			Media.Resolution = UIScreen.MainScreen.Bounds.Size;
			Media.IsRetina = UIScreen.MainScreen.Scale > 1.0;
			Media.DeviceType = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad ? DeviceType.IPad : DeviceType.IPhone;
			#endif

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

