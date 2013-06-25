using System;
using System.Collections.Generic;
using System.Reflection;

namespace Crayon
{
	public interface IControlDecoratorFactory
	{
		Dictionary<Type, Assembly> ControlDecorators { get; }
		List<IControlDecorator> Create(object control);
		List<IControlDecorator> Create (Type type);
		void RegisterDecorator(Type decoratorType, Assembly assembly);
	}
}

