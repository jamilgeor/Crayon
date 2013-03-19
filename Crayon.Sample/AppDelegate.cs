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
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow _window;
		UIButton _button;
		UIViewController _controller;
		StyleContext _styleContext;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			_window = new UIWindow (UIScreen.MainScreen.Bounds);
			_controller = new UIViewController ();

			_styleContext = new StyleContext (new IOSDeviceContext ());
			_styleContext.LoadStyleSheet ("style.css");

			_button = UIButton.FromType (UIButtonType.RoundedRect);
			_button.SetTitle ("Hello", UIControlState.Normal);
			_button.SetStyleId ("sample-button");


			_controller.View.AddSubview (_button);

			// If you have defined a root view controller, set it here:
			_window.RootViewController = _controller;
			
			// make the window visible
			_window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

