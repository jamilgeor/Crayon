using System;

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
	}
}

