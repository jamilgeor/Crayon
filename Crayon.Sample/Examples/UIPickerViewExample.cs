using MonoTouch.UIKit;
using System.Collections.Generic;
using Crayon.MT;

namespace Crayon.Sample
{
	public class UIPickerViewExample : UIViewController
	{
		UIPickerView _pickerView;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_pickerView = new UIPickerView();

			_pickerView.Source = new UIPickerViewModelExample();

			View.SetStyleClass("sample-background");
			_pickerView.SetStyleId("sample-picker");

			View.AddSubview(_pickerView);
		}
	
		class UIPickerViewModelExample : UIPickerViewModel
		{
			List<string> _dataSource;
			
			public UIPickerViewModelExample():base()
			{
				_dataSource = new List<string>(){
					"Item 1",
					"Item 2",
					"Item 3",
					"Item 4",
					"Item 5",
					"Item 6",
					"Item 7"
				};
			}

			public override int GetComponentCount (UIPickerView picker)
			{
				return 1;
			}
			
			public override int GetRowsInComponent (UIPickerView picker, int component)
			{
				return _dataSource.Count;
			}
			
			public override string GetTitle (UIPickerView picker, int row, int component)
			{
				return _dataSource[row];
			}
			
			public override float GetRowHeight (UIPickerView picker, int component)
			{
				return 40f;
			}
		}
	}
}

