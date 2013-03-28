using System;
using System.Collections.Generic;
using System.Reflection;

namespace Crayon
{
	public class ControlDecoratorFactory : BaseFactory
	{
		public static List<IControlDecorator> Create(object control)
		{
			var decorators = new List<IControlDecorator> ();
			var factoryAssembly = Assembly.GetAssembly (StyleContext.Current.StyleFactory.GetType ());
			
			var types = factoryAssembly.GetTypes ();
			
			foreach (var type in types) {
				var attributes = type.GetCustomAttributes(typeof(ControlDecoratorAttribute), true);
				
				foreach (var attribute in attributes) {
					var castAttribute = (ControlDecoratorAttribute)attribute;
					
					if (CanHandleExactType(control.GetType(), castAttribute.ControlType))
						decorators.Add((IControlDecorator)factoryAssembly.CreateInstance(type.FullName));
				}
			}
			
			return decorators;
		}
	}
}

