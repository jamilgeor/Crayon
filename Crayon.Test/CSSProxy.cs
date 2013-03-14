using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Crayon.Test
{
	[TestFixture]
	public class CSSProxy
	{
		[Test]
		public void Load_Test()
		{
			const string path = "simple.css";

			Assert.IsTrue (File.Exists(path));

			var proxy = new StyleProxy ();

			proxy.LoadFromFile (path);

			Assert.IsTrue(proxy.Stylesheet.RuleSets.Any (s1 => s1.Selectors.Any(s => s.SimpleSelectors.Any(ss => ss.ID == "firstId"))));
		}
	}
}
