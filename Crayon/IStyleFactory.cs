using System;

namespace Crayon
{
	public interface IStyleFactory
	{
		void ProcessProperty (StyleProperty property, object control); 
	}
}

