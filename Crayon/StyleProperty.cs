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

	[StyleTerm("width")]
	public class StyleWidthProperty : StyleProperty
	{
		public float Width { get { return (float)Value; } }

		public override void SetValue (string value)
		{
			Value = float.Parse (value);
		}
	}

	[StyleTerm("height")]
	public class StyleHeightProperty : StyleProperty
	{
		public float Height { get { return (float)Value; } }

		public override void SetValue (string value)
		{
			Value = float.Parse (value);
		}
	}

	[StyleTerm("opacity")]
	public class StyleOpacityProperty : StyleProperty
	{
		public float Opacity { get { return (float)Value; } }

		public override void SetValue(string value)
		{
			Value = float.Parse (value);
		}
	}

	[StyleTerm("background-opacity")]
	public class StyleBackgroundOpacityProperty : StyleOpacityProperty { }

	[StyleTerm("top")]
	public class StyleTopProperty : StyleProperty
	{
		public int Top { get { return (int)Value; } }

		public override void SetValue (string value)
		{
			Value = int.Parse (value);
		}
	}

	[StyleTerm("left")]
	public class StyleLeftProperty : StyleProperty
	{
		public int Left { get { return (int)Value; } }
		
		public override void SetValue (string value)
		{
			Value = int.Parse (value);
		}
	}

	[StyleTerm("color")]
	public class StyleColorProperty : StyleProperty
	{
		public Color Color { get { return (Color)Value; } }

		public override void SetValue (string value)
		{
			Value = ColorTranslator.FromHtml (value);
		}
	}

	[StyleTerm("background-color")]
	public class StyleBackgroundColorProperty : StyleColorProperty { }

	[StyleTerm("background-image")]
	public class StyleBackgroundImageProperty : StyleProperty
	{
		public string ImageUrl { get { return (string)Value; } }

		public override void SetValue (string value)
		{
			Value = value;
		}
	}

	[StyleTerm("border-width")]
	public class StyleBorderWidthProperty : StyleWidthProperty { }

	[StyleTerm("border-color")]
	public class StyleBorderColorProperty : StyleColorProperty { }

	[StyleTerm("border-radius")]
	public class StyleBorderRadiusProperty : StyleProperty
	{
		public float Radius { get { return (float)Value; } }

		public override void SetValue (string value)
		{
			Value = float.Parse (value);
		}
	}

	[StyleTerm("text-align")]
	public class StyleTextAlignProperty : StyleProperty
	{
		public Alignment Alignment { get { return (Alignment)Value; } }

		public override void SetValue (string value)
		{
			var alignment = Alignment.Left;
			Enum.TryParse<Alignment>(value, true, out alignment);

			Value = alignment;
		}
	}

	[StyleTerm("font-family")]
	public class StyleFontFamilyProperty : StyleProperty
	{
		public string FontName { get { return Value.ToString(); } }

		public override void SetValue (string value)
		{
			Value = value.Replace ("\"", string.Empty);
		}
	}

	[StyleTerm("font-size")]
	public class StyleFontSizeProperty : StyleProperty
	{
		public float Size { get { return (float)Value; } }

		public override void SetValue(string value)
		{
			Value = float.Parse (value);
		}
	}

	public enum Alignment
	{
		Center,
		Left,
		Right
	}
}

