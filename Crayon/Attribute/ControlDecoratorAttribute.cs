using System;

namespace Crayon
{
	[AttributeUsage(AttributeTargets.Class)]
	public class ControlDecoratorAttribute : Attribute
	{
		public Type ControlType { get; set; }

		public ControlDecoratorAttribute (Type controlType)
		{
			ControlType = controlType;
		}
	}
}

