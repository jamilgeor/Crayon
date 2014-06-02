using System;
using System.Drawing;
using Crayon.Util;

namespace Crayon
{
	public abstract class StyleProperty
	{
		public string Name { get; set; }
		public object Value { get; set; }
		public bool Global { get; set; }

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

	[StyleTerm("padding")]
	public class StylePaddingProperty : StyleProperty
	{
		public Rectangle Padding { get { return (Rectangle)Value; } }

		public override void SetValue(string value)
		{
			int top, right, bottom, left = 0f;
			var points = value.Split (' ');

			if (points.Length > 0)
				top = int.Parse(points [0]);

			if (points.Length > 1)
				right = int.Parse(points [1]);

			if (points.Length > 2)
				bottom = int.Parse(points [2]);

			if (points.Length > 3)
				left = int.Parse(points [3]);

			Value = new Rectangle(left, top, left + ;
		}
	}

	[StyleTerm("padding-top")]
	public class StylePaddingTopProperty : StyleProperty
	{
		public int Padding { get { return (int)Value; } }

		public override void SetValue (string value)
		{
			Value = int.Parse (value);
		}
	}

	[StyleTerm("padding-right")]
	public class StylePaddingRightProperty : StyleProperty
	{
		public int Padding { get { return (int)Value; } }

		public override void SetValue (string value)
		{
			Value = int.Parse (value);
		}
	}

	[StyleTerm("padding-bottom")]
	public class StylePaddingBottomProperty : StyleProperty
	{
		public int Padding { get { return (int)Value; } }

		public override void SetValue (string value)
		{
			Value = int.Parse (value);
		}
	}

	[StyleTerm("padding-left")]
	public class StylePaddingLeftProperty : StyleProperty
	{
		public int Padding { get { return (int)Value; } }

		public override void SetValue (string value)
		{
			Value = int.Parse (value);
		}
	}

	[StyleTerm("tint")]
	public class StyleTintProperty : StyleColorProperty
	{
	}

	[StyleTerm("has-shadow")]
	public class StyleHasShadowProperty : StyleProperty
	{
		public bool HasShadow { get { return (bool)Value; } }

		public override void SetValue(string value)
		{
			Value = bool.Parse (value);
		}
	}

	[StyleTerm("overflow")]
	public class StyleOverflowProperty : StyleProperty
	{
		public bool Scroll { get { return (bool)Value; } }

		public override void SetValue(string value)
		{
			Value = value.Contains ("scroll");
		}
	}

	[StyleTerm("overflow-x")]
	public class StyleOverflowXProperty : StyleProperty
	{
		public bool Scroll { get { return (bool)Value; } }

		public override void SetValue(string value)
		{
			Value = value.Contains ("scroll");
		}
	}

	[StyleTerm("overflow-y")]
	public class StyleOverflowYProperty : StyleProperty
	{
		public bool Scroll { get { return (bool)Value; } }

		public override void SetValue(string value)
		{
			Value = value.Contains ("scroll");
		}
	}

	public enum Alignment
	{
		Center,
		Left,
		Right
	}
}

