using System;
using Xamarin.Forms;

namespace Crayon.Forms.MT
{
	[ControlDecorator(typeof(Layout), "layout")]
	public abstract class LayoutDecorator<T> : BaseDecorator<T> where T : Layout
	{
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

		[StyleProperty(typeof(StyleWidthProperty))]
		public void SetWidth(StyleWidthProperty property)
		{
			var bounds = View.Bounds;
			bounds.Width = property.Width;

			View.Layout (bounds);
		}

		[StyleProperty(typeof(StyleHeightProperty))]
		public void SetHeight(StyleHeightProperty property)
		{
			var bounds = View.Bounds;
			bounds.Height = property.Height;

			View.Layout (bounds);
		}

		[StyleProperty(typeof(StyleTopProperty))]
		public void SetTop(StyleTopProperty property)
		{
			var bounds = View.Bounds;
			bounds.Top = property.Top;

			View.Layout (bounds);
		}

		[StyleProperty(typeof(StyleLeftProperty))]
		public void SetLeft(StyleLeftProperty property)
		{
			var bounds = View.Bounds;
			bounds.Left = property.Left;

			View.Layout (bounds);
		}
	}

	[ControlDecorator(typeof(ContentView), "content-layout")]
	public class ContentPageDecorator : LayoutDecorator<ContentView>
	{
	}

	[ControlDecorator(typeof(Frame), "frame-layout")]
	public class FrameDecorator : LayoutDecorator<Frame>
	{
		[StyleProperty(typeof(StyleBorderColorProperty))]
		public void SetOutlineColor(StyleBorderColorProperty property)
		{
			View.OutlineColor = new Color (property.Color.R, property.Color.G, property.Color.A);
		}

		[StyleProperty(typeof(StyleHasShadowProperty))]
		public void SetHasShadow(StyleHasShadowProperty property)
		{
			View.HasShadow = property.HasShadow;
		}
	}

	[ControlDecorator(typeof(ScrollView), "scroll-layout")]
	public class ScrollViewDecorator : LayoutDecorator<ScrollView>
	{
		[StyleProperty(typeof(StyleWidthProperty))]
		public void SetContentSizeWidth(StyleWidthProperty property)
		{
			View.ContentSize.Width = property.Width;
		}

		[StyleProperty(typeof(StyleHeightProperty))]
		public void SetContentSizeHeight(StyleHeightProperty property)
		{
			View.ContentSize.Height = property.Height;
		}

		[StyleProperty(typeof(StyleOverflowProperty))]
		public void SetScrollOrientation(StyleOverflowProperty property)
		{
			if (property.Scroll)
				View.Orientation = ScrollOrientation.Horizontal | ScrollOrientation.Vertical;
			else
				View.Orientation = ScrollOrientation.Vertical;
		}

		[StyleProperty(typeof(StyleOverflowXProperty))]
		public void SetScrollOrientationHorizontal(StyleOverflowXProperty property)
		{
			View.Orientation = property.Scroll ? ScrollOrientation.Horizontal : ScrollOrientation.Vertical;
		}

		[StyleProperty(typeof(StyleOverflowYProperty))]
		public void SetScrollOrientationVertical(StyleOverflowYProperty property)
		{
			View.Orientation = !property.Scroll ? ScrollOrientation.Horizontal : ScrollOrientation.Vertical;
		}
	}

	[ControlDecorator(typeof(AbsoluteLayout), "absolute-layout")]
	public class AbsoluteDecorator : LayoutDecorator<AbsoluteLayout>
	{

	}

	[ControlDecorator(typeof(RelativeLayout), "relative-layout")]
	public class RelativeDecorator : LayoutDecorator<RelativeLayout>
	{

	}

	[ControlDecorator(typeof(StackLayout), "stack-layout")]
	public class StackDecorator : LayoutDecorator<StackLayout>
	{
		[StyleProperty(typeof(StyleProxy))]
		public void SetOrientation(StyleOrientationProperty property)
		{
			View.Orientation = property.Orientation == Orientation.Horizontal ? StackOrientation.Horizontal | StackOrientation.Vertical;
		}
	}
}

