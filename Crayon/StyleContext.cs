using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Crayon
{
	public class StyleContext
	{
		internal IDeviceContext DeviceContext { get; private set; }

		IStyleProxy _proxy;
		IControlDecoratorFactory _decoratorFactory;

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

		public StyleContext(IDeviceContext deviceContext) : this(deviceContext, new StyleProxy(), new ControlDecoratorFactory()){}
		public StyleContext(IDeviceContext deviceContext, IStyleProxy proxy, IControlDecoratorFactory decoratorFactory)
		{
			DeviceContext = deviceContext;

			_proxy = proxy;
			_decoratorFactory = decoratorFactory;

			Current = this;

			RegisterDefaultControlDectorators();
		}

		private void RegisterDefaultControlDectorators()
		{
			var assembly = Assembly.GetAssembly(DeviceContext.GetType());

			foreach(var decoratorType in DeviceContext.GetControlDecorators())
				_decoratorFactory.RegisterDecorator(decoratorType, assembly);
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

		void ProcessStyleProperties(IEnumerable<StyleProperty> styleProperties, object control)
		{
			var controlDecorators = _decoratorFactory.Create (control);

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

