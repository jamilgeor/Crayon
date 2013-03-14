using System;
using System.Linq;
using System.Reflection;

namespace Crayon
{
	public static class StylePropertyFactory
	{
		public static StyleProperty Create(string term)
		{
			var currentAssembly = Assembly.GetExecutingAssembly ();
			var stylePropertyType = FindStylePropertyTypeByTerm (term, currentAssembly);

			if (stylePropertyType == null)
				return null;

			return (StyleProperty)currentAssembly.CreateInstance (stylePropertyType.FullName);
		}

		static Type FindStylePropertyTypeByTerm(string term, Assembly assembly)
		{
			var types = assembly.GetTypes().Where(t => t.BaseType != null && t.BaseType.FullName == typeof(StyleProperty).FullName);
			
			foreach (var type in types) 
			{
				var attributes = type.GetCustomAttributes(typeof(StyleTermHandlerAttribute), true);

				foreach (var attribute in attributes)
				{
					if (AttributeMatchesTerm(attribute, term))
						return type;
				}
			}
			
			return null;
		}

		static bool AttributeMatchesTerm(object attribute, string term)
		{
			var name = typeof(StyleTermHandlerAttribute).GetProperty("Name").GetValue(attribute, null).ToString();

			return name == term;
		}
	}
}

