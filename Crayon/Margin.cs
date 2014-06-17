using System;
using System.Drawing;
using Crayon.Util;

namespace Crayon
{
	public class Margin
	{
		public int Top { get; set; }
		public int Right { get; set; }
		public int Bottom { get; set; }
		public int Left { get; set; }

		public Margin(){}
		public Margin(int top, int right, int bottom, int left)
		{
			Top = top;
			Right = right;
			Bottom = bottom;
			Left = left;
		}

		public static Margin Parse(string value)
		{
			var margin = new Margin ();
			var points = value.Split (' ');

			if (points.Length > 0)
				margin.Top = int.Parse(points [0]);

			if (points.Length > 1)
				margin.Right = int.Parse(points [1]);

			if (points.Length > 2)
				margin.Bottom = int.Parse(points [2]);

			if (points.Length > 3)
				margin.Left = int.Parse(points [3]);

			return margin;
		}
	}
}

	

	

	

	

	

	

	

	

	

	

	

	

	

	

	

	

	

	

	

	

	

	

	

	

	

	
}

