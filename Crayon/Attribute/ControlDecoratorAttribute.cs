using System;

namespace Crayon
{
	[AttributeUsage(AttributeTargets.Class)]
	public class ControlDecoratorAttribute : Attribute
	{
		public Type ControlType { get; set; }
		public string GlobalSelector { get; set; }

		public ControlDecoratorAttribute (Type controlType, string globalSelector)
		{
			ControlType = controlType;
			GlobalSelector = globalSelector;
		}
	}
}

