using System;
using System.Collections.Generic;

namespace Crayon
{
	public interface IStyleProxy
	{
		void LoadFromFile(string path);
		IEnumerable<StyleProperty> GetStylesById (string styleId);
		IEnumerable<StyleProperty> GetStylesByClass (string classId);
		IEnumerable<StyleProperty> GetGlobalStyles();
	}
}

