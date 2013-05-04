using System;
using System.Collections.Generic;

namespace Crayon
{
	public interface IDeviceContext
	{
		Media Media { get; }
		IList<Type> GetControlDecorators();
	}
}

