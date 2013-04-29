using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

using ExCSS;
using ExCSS.Model;

namespace Crayon
{
	public class StyleProxy : IStyleProxy
	{
		public Stylesheet Stylesheet{ get; private set; }

		public void LoadFromFile(string path)
		{
			var parser = new StylesheetParser ();

			using (var stream = new FileStream(path, FileMode.Open)) {
				parser.Parse(stream);
			}

			Stylesheet = parser.Stylesheet;
		}

		public void LoadFromString(string content)
		{
			var parser = new StylesheetParser();

			parser.Parse (content);

			Stylesheet = parser.Stylesheet;
		}

		public IEnumerable<StyleProperty> GetStylesById(string styleId)
		{
			return GetStyles (s => s.ID == styleId);
		}

		public IEnumerable<StyleProperty> GetStylesByClass(string classId)
		{
			return GetStyles (s => s.Class == classId);
		}

		public IEnumerable<StyleProperty> GetGlobalStyles()
		{
			return GetStyles (s => s.ElementName == "*");
		}

		IEnumerable<StyleProperty> GetStyles(Func<SimpleSelector, bool> filter)
		{
			var properties = new List<StyleProperty> ();
			
			var declarations = GetDeclarations(filter);
			
			declarations.ForEach(d => properties.AddRange(CreateStyleProperties(d)));
			
			return properties;
		}

		List<Declaration> GetDeclarations (Func<SimpleSelector, bool> filter) 
		{
			var declarations = new List<Declaration> ();

			foreach (var ruleset in Stylesheet.RuleSets) {
				foreach(var selector in ruleset.Selectors) {
					if (selector.SimpleSelectors.Any(filter))
						declarations.AddRange(ruleset.Declarations);
				}
			}

			return declarations;
		}

		static IEnumerable<StyleProperty> CreateStyleProperties(Declaration declaration)
		{
			var properties = new List<StyleProperty> ();

			foreach(var term in declaration.Expression.Terms) {
				var property = StylePropertyFactory.Create(declaration.Name.ToLower());
				
				if (property != null)
				{
					property.SetValue(term.Value);
					properties.Add(property);
				}
			}

			return properties;
		}
	}
}

