using System;
using System.Linq;
using System.Reflection;

namespace Crayon
{
	public class StylePropertyFactory : BaseFactory
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
			var types = assembly.GetTypes().Where(t => t.BaseType != null && CanHandleType(t, typeof(StyleProperty)));
			
			foreach (var type in types) 
			{
				var attributes = type.GetCustomAttributes(typeof(StyleTermAttribute), true);

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
			var name = typeof(StyleTermAttribute).GetProperty("Name").GetValue(attribute, null).ToString();

			return name == term;
		}
	}
}

