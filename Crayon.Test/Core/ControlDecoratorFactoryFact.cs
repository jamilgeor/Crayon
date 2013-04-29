using System;
using System.Linq;

using MonoTouch.UIKit;

using Crayon;
using Crayon.MT;

using NUnit.Framework;

namespace Crayon.Test
{
	public class ControlDecoratorFactoryFact
	{
		[TestFixture]
		public class Create
		{
			StyleContext _context;

			[TestFixtureSetUp]
			public void Setup()
			{
				_context = new StyleContext (new IOSDeviceContext ());
			}

			[Test]
			public void With_Unsupported_Control_Type()
			{
				var control = new UnsupportedControl ();

				var result = ControlDecoratorFactory.Create (control);

				Assert.IsFalse (result.Any ());
			}

			[Test]
			public void With_Base_Control_Type()
			{
				const int expectedNumberOfDecorators = 1;
				var control = new UIView ();

				var result = ControlDecoratorFactory.Create (control);

				Assert.True (result.Any ());
				Assert.AreEqual (expectedNumberOfDecorators, result.Count);
				Assert.IsTrue (result.First () is UIViewDecorator);
			}

			[Test]
			public void With_Inherited_Control_Type()
			{
				const int expectedNumberOfDecorators = 1;
				var control = new UIButton ();
				
				var result = ControlDecoratorFactory.Create (control);
				
				Assert.True (result.Any ());
				Assert.AreEqual (expectedNumberOfDecorators, result.Count);
				Assert.IsTrue (result.First() is UIButtonDecorator);
			}
		}

		public class UnsupportedControl { }
	}
}

