using System;

namespace Crayon
{
	[AttributeUsage(AttributeTargets.Method)]
	public class StylePropertyAttribute : Attribute
	{
		public Type StylePropertyType { get; set; }

		public StylePropertyAttribute (Type stylePropertyType)
		{
			StylePropertyType = stylePropertyType;
		}
	}
}

