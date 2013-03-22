using System;

namespace Crayon
{
	[AttributeUsage(AttributeTargets.Class)]
	public class StyleTermAttribute : Attribute
	{
		public string Name { get; set; }

		public StyleTermAttribute(string name)
		{
			Name = name;
		}
	}
}

