using System;
using System.Reflection;

namespace Crayon
{
	internal class ControlDecoratorFactory
	{
		internal static IControlDecorator Create(object control)
		{
			var factoryAssembly = Assembly.GetAssembly (StyleContext.Current.StyleFactory.GetType ());
			
			var types = factoryAssembly.GetTypes ();
			
			foreach (var type in types) {
				var attributes = type.GetCustomAttributes(typeof(ControlHandlerAttribute), true);
				
				foreach (var attribute in attributes) {
					var castAttribute = (ControlHandlerAttribute)attribute;
					
					if (CanHandleType(control.GetType(), castAttribute.ControlType))
						return (IControlDecorator)factoryAssembly.CreateInstance(type.FullName);
				}
			}
			
			return null;
		}
		
		static bool CanHandleType (Type type, Type typeToMatch)
		{
			if (type == typeToMatch) {
				return true;
			}
			
			if (type.BaseType != null)
				return CanHandleType (type.BaseType, typeToMatch);
			
			return false;
		}
	}
}

