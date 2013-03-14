using System;

namespace Crayon
{
	public abstract class StyleProperty
	{
		public string Name { get; set; }
		public object Value { get; set; }

		public abstract void SetValue (string value);
	}

	[StyleTermHandlerAttribute("width")]
	public class StyleWidthProperty : StyleProperty
	{
		public int Width { get { return (int)Value; } }

		public override void SetValue (string value)
		{
			Value = int.Parse (value);
		}
	}

	[StyleTermHandlerAttribute("height")]
	public class StyleHeightProperty : StyleProperty
	{
		public int Height { get { return (int)Value; } }

		public override void SetValue (string value)
		{
			Value = int.Parse (value);
		}
	}
}

