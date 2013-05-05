using System;
using System.Collections.Generic;
using System.Reflection;

namespace Crayon
{
	public interface IControlDecoratorFactory
	{
		List<IControlDecorator> Create(object control);
		void RegisterDecorator(Type decoratorType, Assembly assembly);
	}
}

