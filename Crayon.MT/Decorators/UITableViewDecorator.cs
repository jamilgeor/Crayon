using System;
using MonoTouch.UIKit;
using Crayon;

namespace Crayon.MT
{
	[ControlDecorator(typeof(UITableView), "table")]
	public class UITableViewDecorator : BaseDecorator<UITableView>
	{
	}
}

