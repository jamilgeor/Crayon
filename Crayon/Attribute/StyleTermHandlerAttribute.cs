using System;

namespace Crayon
{
	[AttributeUsage(AttributeTargets.Class)]
	public class StyleTermHandlerAttribute : Attribute
	{
		public string Name { get; set; }

		public StyleTermHandlerAttribute(string name)
		{
			Name = name;
		}
	}
}

