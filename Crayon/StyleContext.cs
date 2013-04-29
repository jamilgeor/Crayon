using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Crayon
{
	public class StyleContext
	{
		internal IDeviceContext StyleFactory { get; private set; }

		IStyleProxy _proxy;
		static StyleContext _current;

		public static StyleContext Current 
		{ 
			get
			{
				if (_current == null)
					throw new Exception("Style context not instantiated.");

				return _current;
			}

			private set
			{
				_current = value;
			}
		}

		public StyleContext(IDeviceContext factory) : this(factory, new StyleProxy()){}
		public StyleContext(IDeviceContext factory, IStyleProxy proxy)
		{
			StyleFactory = factory;
			_proxy = proxy;
			Current = this;
		}

		public void LoadStyleSheetFromFile(string path)
		{
			_proxy.LoadFromFile (path);
		}

		public void LoadStyleSheetFromStream(Stream stream)
		{
			_proxy.LoadFromStream(stream);
		}

		public void LoadStyleSheetFromString(string content)
		{
			_proxy.LoadFromString(content);
		}

		public void SetStyleById(string styleId, object targetControl)
		{
			ProcessStyleProperties (_proxy.GetGlobalStyles (), targetControl);
			ProcessStyleProperties (_proxy.GetStylesById(styleId), targetControl);
		}

		public void SetStyleByClass(string styleClass, object targetControl)
		{
			ProcessStyleProperties (_proxy.GetGlobalStyles (), targetControl);
			ProcessStyleProperties (_proxy.GetStylesByClass (styleClass), targetControl);
		}

		static void ProcessStyleProperties(IEnumerable<StyleProperty> styleProperties, object control)
		{
			var controlDecorators = ControlDecoratorFactory.Create (control);

			foreach (var controlDecorator in controlDecorators) {
				controlDecorator.SetControl (control);
			
				foreach (var property in styleProperties) {
					InvokeStylePropertySetter(controlDecorator, property);
				}
			}
		}

		static void InvokeStylePropertySetter(IControlDecorator controlHandler, StyleProperty property)
		{
			var methods = controlHandler.GetType ().GetMethods ();

			foreach (var method in methods)
			{
				var attributes = method.GetCustomAttributes(typeof(StylePropertyAttribute), true);

				if(attributes.Any(a => (a as StylePropertyAttribute).StylePropertyType == property.GetType()))
				{
					method.Invoke(controlHandler, new object[]{property});
				}
			}
		}
	}
}

