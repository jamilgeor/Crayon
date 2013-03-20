using System;
using System.Drawing;

namespace Crayon
{
	public class Media
	{
		public DeviceType DeviceType { get; set; }
		public SizeF Resolution { get; set; }
		public bool IsRetina { get; set; }
	}

	public enum DeviceType
	{
		IPad,
		IPhone,
		AndroidTablet,
		AndroidPhone
	}
}

