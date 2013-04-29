using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Crayon;
using Crayon.MT;

namespace Crayon.Sample
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow _window;
		ExampleNavigationController _navigator;

		StyleContext _styleContext;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			_window = new UIWindow (UIScreen.MainScreen.Bounds);

			_styleContext = new StyleContext (new IOSDeviceContext ());
			_styleContext.LoadStyleSheetFromFile ("style.css");
			
			_navigator = new ExampleNavigationController ();

			_window.RootViewController = _navigator;
			
			_window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

