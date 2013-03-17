using System;

namespace System.Drawing {
	
	public sealed class ColorTranslator {
		
		public static Color FromHtml (string htmlColor)
		{
			htmlColor = htmlColor.TrimStart ('#');

			if (string.IsNullOrEmpty(htmlColor))
				return Color.Empty;

			//Add alpha value if not specified
			if (htmlColor.Length == 6)
				htmlColor = string.Format ("FF{0}", htmlColor);

			var value = int.Parse (htmlColor, System.Globalization.NumberStyles.HexNumber);

			return Color.FromArgb(value);
		}
	}
}