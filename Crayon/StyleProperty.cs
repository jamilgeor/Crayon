using System;
using System.Drawing;
using Crayon.Util;

namespace Crayon
{
	public abstract class StyleProperty
	{
		public string Name { get; set; }
		public object Value { get; set; }

		public abstract void SetValue (string value);
	}

	[StyleTermHandler("width")]
	public class StyleWidthProperty : StyleProperty
	{
		public int Width { get { return (int)Value; } }

		public override void SetValue (string value)
		{
			Value = int.Parse (value);
		}
	}

	[StyleTermHandler("height")]
	public class StyleHeightProperty : StyleProperty
	{
		public int Height { get { return (int)Value; } }

		public override void SetValue (string value)
		{
			Value = int.Parse (value);
		}
	}

	[StyleTermHandler("opacity")]
	public class StyleOpacityProperty : StyleProperty
	{
		public float Opacity { get { return (float)Value; } }

		public override void SetValue(string value)
		{
			Value = float.Parse (value);
		}
	}

	[StyleTermHandler("top")]
	public class StyleTopProperty : StyleProperty
	{
		public int Top { get { return (int)Value; } }

		public override void SetValue (string value)
		{
			Value = int.Parse (value);
		}
	}

	[StyleTermHandler("left")]
	public class StyleLeftProperty : StyleProperty
	{
		public int Left { get { return (int)Value; } }
		
		public override void SetValue (string value)
		{
			Value = int.Parse (value);
		}
	}

	[StyleTermHandler("color")]
	public class StyleColorProperty : StyleProperty
	{
		public Color Color { get { return (Color)Value; } }

		public override void SetValue (string value)
		{
			Value = ColorTranslator.FromHtml (value);
		}
	}

	[StyleTermHandler("background-color")]
	public class StyleBackgroundColorProperty : StyleColorProperty { }
}

