using System;
using System.Collections.Generic;
using System.Linq;

namespace Crayon
{
	public class BaseFactory
	{
		protected static bool CanHandleType (Type type, Type typeToMatch)
		{
			if (type == typeToMatch)
				return true;

			//Recurse up inheritance tree if types don't match
			if (type.BaseType != null)
				return CanHandleType (type.BaseType, typeToMatch);
			
			return false;
		}
	}
}

