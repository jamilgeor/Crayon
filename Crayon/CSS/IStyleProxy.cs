using System;
using System.Collections.Generic;

namespace Crayon
{
	public interface IStyleProxy
	{
		void LoadFromFile(string path);
		void LoadFromString(string content);
		IEnumerable<StyleProperty> GetStylesById (string styleId);
		IEnumerable<StyleProperty> GetStylesByClass (string classId);
		IEnumerable<StyleProperty> GetGlobalStyles();
	}
}

