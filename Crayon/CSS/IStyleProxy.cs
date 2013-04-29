using System;
using System.Collections.Generic;
using System.IO;

namespace Crayon
{
	public interface IStyleProxy
	{
		void LoadFromFile(string path);
		void LoadFromStream (Stream stream);
		void LoadFromString(string content);
		IEnumerable<StyleProperty> GetStylesById (string styleId);
		IEnumerable<StyleProperty> GetStylesByClass (string classId);
		IEnumerable<StyleProperty> GetGlobalStyles();
	}
}

