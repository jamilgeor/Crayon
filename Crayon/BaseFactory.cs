using System;
using System.Collections.Generic;
using System.Linq;

namespace Crayon
{
	public class BaseFactory
	{
		protected static bool CanHandleType (Type type, Type typeToMatch)
		{
			if (type == typeToMatch) {
				return true;
			}
			
			if (type.BaseType != null)
				return CanHandleType (type.BaseType, typeToMatch);
			
			return false;
		}

		protected static bool CanHandleExactType (Type type, Type typeToMatch)
		{
			return type == typeToMatch;
		}
	}
}

