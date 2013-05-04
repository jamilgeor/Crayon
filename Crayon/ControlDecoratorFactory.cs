using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Crayon
{
	public class ControlDecoratorFactory : BaseFactory
	{
		static readonly Dictionary<Type, Assembly> _controlDecorators = new Dictionary<Type, Assembly>();

		public static List<IControlDecorator> Create(object control)
		{
			var decorators = CreateDecoratorsForType(control.GetType());

			return decorators;
		}

		static List<IControlDecorator> CreateDecoratorsForType(Type type)
		{
			var decorators = new List<IControlDecorator> ();

			foreach (var valuePair in _controlDecorators) {
				var decorator = valuePair.Key;
				var assembly = valuePair.Value;

				if (CanDecorate(type, decorator))
					decorators.Add((IControlDecorator)assembly.CreateInstance(decorator.FullName));
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
				
				if (type == castAttribute.ControlType)
					return true;
			}

			return false;
		}

		public static void RegisterDecorator(Type decoratorType, Assembly assembly)
		{
			_controlDecorators.Add(decoratorType, assembly);
		}
	}
}

