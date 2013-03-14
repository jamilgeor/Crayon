using System;

namespace Crayon
{
	[AttributeUsage(AttributeTargets.Class)]
	public class ControlHandlerAttribute : Attribute
	{
		public Type ControlType { get; set; }

		public ControlHandlerAttribute (Type controlType)
		{
			ControlType = controlType;
		}
	}
}

