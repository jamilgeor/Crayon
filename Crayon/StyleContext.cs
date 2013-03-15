using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Crayon
{
	public class StyleContext
	{
		internal IStyleFactory StyleFactory { get; private set; }

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

		public StyleContext(IStyleFactory factory) : this(factory, new StyleProxy()){}
		public StyleContext(IStyleFactory factory, IStyleProxy proxy)
		{
			StyleFactory = factory;
			_proxy = proxy;
			Current = this;
		}

		public void LoadStyleSheet(string path)
		{
			_proxy.LoadFromFile (path);
		}

		public void SetStyleById(string styleId, object targetControl)
		{
			ProcessStyleProperties (_proxy.GetStylesById(styleId), targetControl);
		}

		public void SetStyleByClass(string styleClass, object targetControl)
		{
			ProcessStyleProperties (_proxy.GetStylesByClass (styleClass), targetControl);
		}

		static void ProcessStyleProperties(IEnumerable<StyleProperty> styleProperties, object control)
		{
			var controlHandler = ControlDecoratorFactory.Create (control);

			if (controlHandler == null)
				return;

			controlHandler.SetControl (control);

			foreach (var property in styleProperties) {
				InvokeStylePropertySetter(controlHandler, property);
			}
		}

		static void InvokeStylePropertySetter(IControlDecorator controlHandler, StyleProperty property)
		{
			var methods = controlHandler.GetType ().GetMethods ();

			foreach (var method in methods)
			{
				var attributes = method.GetCustomAttributes(typeof(StylePropertyHandlerAttribute), true);

				if(attributes.Any(a => (a as StylePropertyHandlerAttribute).StylePropertyType == property.GetType()))
				{
					method.Invoke(controlHandler, new object[]{property});
				}
			}
		}
	}
}

