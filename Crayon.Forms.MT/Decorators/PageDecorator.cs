using System;
using Xamarin.Forms;

namespace Crayon.Forms
{
	[ControlDecorator(typeof(Page), "page")]
	public abstract class PageDecorator<T> : BaseDecorator<T> where T : Page
	{
		[StyleProperty(typeof(StyleBackgroundImageProperty))]
		public virtual void SetBackgroundImage(StyleBackgroundImageProperty property)
		{
			View.BackgroundImage = property.ImageUrl;
		}

		[StyleProperty(typeof(StylePaddingProperty))]
		public virtual void SetPadding(StylePaddingProperty property)
		{
			View.Padding.Top = property.Padding.Top;
			View.Padding.Right = property.Padding.Right;
			View.Padding.Bottom = property.Padding.Bottom;
			View.Padding.Left = property.Padding.Left;
		}

		[StyleProperty(typeof(StylePaddingTopProperty))]
		public virtual void SetPadding(StylePaddingTopProperty property)
		{
			View.Padding.Top = property.Padding;
		}

		[StyleProperty(typeof(StylePaddingRightProperty))]
		public virtual void SetPadding(StylePaddingRightProperty property)
		{
			View.Padding.Right = property.Padding;
		}

		[StyleProperty(typeof(StylePaddingBottomProperty))]
		public virtual void SetPadding(StylePaddingBottomProperty property)
		{
			View.Padding.Bottom = property.Padding;
		}

		[StyleProperty(typeof(StylePaddingLeftProperty))]
		public virtual void SetPadding(StylePaddingLeftProperty property)
		{
			View.Padding.Left = property.Padding;
		}
	}

	[ControlDecorator(typeof(ContentPage), "page")]
	public class ContentPageDecorator : PageDecorator<ContentPage>
	{
	}

	[ControlDecorator(typeof(MasterDetailPage), "page")]
	public class MasterDetailPageDecorator : PageDecorator<MasterDetailPage>
	{
	}

	[ControlDecorator(typeof(NavigationPage), "page")]
	public class NavigationPageDecorator : PageDecorator<NavigationPage>
	{
		[StyleProperty(typeof(StyleTintProperty))]
		public virtual void SetTint(StyleTintProperty property)
		{
			View.Tint = new Color(property.Color.R, property.Color.G, property.Color.B, property.Color.A);
		}
	}

	[ControlDecorator(typeof(TabbedPage), "page")]
	public class TabbedPageDecorator : PageDecorator<TabbedPage>
	{
	}

	[ControlDecorator(typeof(CarouselPage), "page")]
	public class CarouselPageDecorator : PageDecorator<CarouselPage>
	{
	}
}

