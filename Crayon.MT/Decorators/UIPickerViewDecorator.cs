using System;
using MonoTouch.UIKit;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UIPickerView), "picker")]
	public class UIPickerViewDecorator : BaseDecorator<UIPickerView>
	{
	}
}

