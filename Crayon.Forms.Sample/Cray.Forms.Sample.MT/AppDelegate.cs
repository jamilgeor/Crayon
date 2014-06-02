using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Crayon.Forms.Sample.Views;
using Xamarin.Forms;
using Crayon;
using Crayon.Forms;

namespace Cray.Forms.Sample.MT
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		StyleContext _styleContext;
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Xamarin.Forms.Forms.Init ();

			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			// If you have defined a root view controller, set it here:

			_styleContext = new StyleContext (new FormsContext ());
			_styleContext.LoadStyleSheetFromFile ("style.css");

			var page = App.GetMainPage ();

			page.InitializeStyles ();

			window.RootViewController = page.CreateViewController();
			
			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

