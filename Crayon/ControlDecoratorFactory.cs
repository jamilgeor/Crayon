using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Crayon
{
	public class ControlDecoratorFactory : BaseFactory
	{
		public static List<IControlDecorator> Create(object control)
		{
			var decorators = CreateDecoratorsForType(control.GetType());

			return decorators;
		}

		static List<IControlDecorator> CreateDecoratorsForType(Type type)
		{
			var decorators = new List<IControlDecorator> ();

			var factoryAssembly = Assembly.GetAssembly (StyleContext.Current.StyleFactory.GetType ());
			
			var types = factoryAssembly.GetTypes ();
			
			foreach (var decoratorType in types) {
				if (CanDecorate(type, decoratorType))
					decorators.Add((IControlDecorator)factoryAssembly.CreateInstance(decoratorType.FullName));
			}

			if (!decorators.Any () && type.BaseType != typeof(object))
				decorators = CreateDecoratorsForType(type.BaseType);

			return decorators;
		}

		static bool CanDecorate(Type type, Type decoratorType)
		{
			var attributes = decoratorType.GetCustomAttributes(typeof(ControlDecoratorAttribute), true);

			foreach (var attribute in attributes) {
				var castAttribute = (ControlDecoratorAttribute)attribute;
				
				if (CanHandleExactType(type, castAttribute.ControlType))
					return true;
			}

			return false;
		}
	}
}

