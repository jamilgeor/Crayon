using System;
using System.Drawing;
using Xamarin.Forms;

namespace Crayon.Forms
{
	public abstract class BaseDecorator<T> : IControlDecorator where T : VisualElement
	{
		protected T View { get; private set; } 

		public void SetControl(object control)
		{
			View = (T)control;
		}

		[StyleProperty(typeof(StyleWidthProperty))]
		public virtual void SetWidth(StyleWidthProperty property)
		{
			View.WidthRequest = property.Width;
		}
		
		[StyleProperty(typeof(StyleHeightProperty))]
		public virtual void SetHeight(StyleHeightProperty property)
		{
			View.HeightRequest = property.Height;
		}
		
		[StyleProperty(typeof(StyleOpacityProperty))]
		public virtual void SetOpacity(StyleOpacityProperty property)
		{
			View.Opacity = property.Opacity;
		}
		
		[StyleProperty(typeof(StyleTopProperty))]
		public virtual void SetTop(StyleTopProperty property)
		{
			View.Layout (new Xamarin.Forms.Rectangle (View.X, property.Top, View.Width, View.Height));
		}
		
		[StyleProperty(typeof(StyleLeftProperty))]
		public virtual void SetLeft(StyleLeftProperty property)
		{
			View.Layout (new Xamarin.Forms.Rectangle (property.Left, View.Y, View.Width, View.Height));
		}
		
		[StyleProperty(typeof(StyleBackgroundColorProperty))]
		public virtual void SetBackgroundColor(StyleBackgroundColorProperty property)
		{
			View.BackgroundColor = Xamarin.Forms.Color.FromRgba ((int)property.Color.R, (int)property.Color.G, (int)property.Color.B, (int)property.Color.A);
		}
	}
}

