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
			[Test]
			public void With_Unsupported_Control_Type()
			{
				var factory = new ControlDecoratorFactory();

				var control = new UnsupportedControl ();

				var result = factory.Create (control);

				Assert.IsFalse (result.Any ());
			}

			[Test]
			public void With_Base_Control_Type()
			{
				const int expectedNumberOfDecorators = 1;

				var control = new UIView ();

				var factory = new ControlDecoratorFactory();
				factory.RegisterDecorator(typeof(UIViewDecorator), typeof(UIViewDecorator).Assembly);

				var result = factory.Create (control);

				Assert.True (result.Any ());
				Assert.AreEqual (expectedNumberOfDecorators, result.Count);
				Assert.IsTrue (result.First () is UIViewDecorator);
			}

			[Test]
			public void With_Inherited_Control_Type()
			{
				const int expectedNumberOfDecorators = 1;

				var control = new UIButton ();

				var factory = new ControlDecoratorFactory();
				factory.RegisterDecorator(typeof(UIButtonDecorator), typeof(UIButtonDecorator).Assembly);

				var result = factory.Create (control);
				
				Assert.True (result.Any ());
				Assert.AreEqual (expectedNumberOfDecorators, result.Count);
				Assert.IsTrue (result.First() is UIButtonDecorator);
			}
		}

		public class UnsupportedControl { }
	}
}

