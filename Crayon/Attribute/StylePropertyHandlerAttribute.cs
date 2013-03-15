using System;

namespace Crayon
{
	[AttributeUsage(AttributeTargets.Method)]
	public class StylePropertyHandlerAttribute : Attribute
	{
		public Type StylePropertyType { get; set; }

		public StylePropertyHandlerAttribute (Type stylePropertyType)
		{
			StylePropertyType = stylePropertyType;
		}
	}
}

