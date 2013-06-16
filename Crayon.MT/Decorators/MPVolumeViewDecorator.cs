using System;
using MonoTouch.MediaPlayer;

namespace Crayon.MT
{
	[ControlDecorator(typeof(MPVolumeView), "volume")]
	public class MPVolumeViewDecorator : BaseDecorator<MPVolumeView>
	{
	}
}

