using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using Crayon;

namespace Crayon.Test.Core
{
	public class StyleProxyFact
	{
		[TestFixture]
		public class LoadFromFile
		{
			[Test]
			public void Normal_File()
			{
				const string path = "simple.css";

				Assert.IsTrue (File.Exists(path));

				var proxy = new StyleProxy ();

				proxy.LoadFromFile (path);

				Assert.IsTrue(proxy.Stylesheet.RuleSets.Any (s1 => s1.Selectors.Any(s => s.SimpleSelectors.Any(ss => ss.ID == "firstId"))));
			}

			[Test]
			public void Non_Existent_File()
			{
				const string path = "non_existent_file.css";

				Assert.IsFalse (File.Exists (path));

				var proxy = new StyleProxy ();

				Assert.Throws(typeof(FileNotFoundException), () => proxy.LoadFromFile(path));
			}
		}

		[TestFixture]
		public class GetStylesById
		{
			StyleProxy _proxy;

			[TestFixtureSetUp]
			public void TestFixtureSetup()
			{
				const string path = "simple.css";

				_proxy = new StyleProxy ();
				_proxy.LoadFromFile (path);
			}

			[Test]
			public void StyleId_Defined_Once()
			{
				const int expectedNumberOfStyles = 3;
				const int expectedWidth = 20;
				const int expectedHeight = 30;

				var styles = _proxy.GetStylesById ("firstId").ToList();

				Assert.IsNotNull (styles);
				Assert.IsTrue (styles.Any());
				Assert.AreEqual (expectedNumberOfStyles, styles.Count ());

				Assert.IsTrue (styles[0] is StyleWidthProperty);
				Assert.AreEqual (expectedWidth, (styles[0] as StyleWidthProperty).Width);
				Assert.IsTrue (styles[1] is StyleHeightProperty);
				Assert.AreEqual (expectedHeight, (styles[1] as StyleHeightProperty).Height);
			}

			[Test]
			public void StyleId_Defined_More_Than_Once()
			{
				const int expectedNumberOfStyles = 2;
				const int expectedWidth = 50;
				const int expectedHeight = 100;

				var styles = _proxy.GetStylesById ("secondId").ToList();
				
				Assert.IsNotNull (styles);
				Assert.IsTrue (styles.Any());
				Assert.AreEqual (expectedNumberOfStyles, styles.Count ());

				Assert.IsTrue (styles[0] is StyleWidthProperty);
				Assert.AreEqual (expectedWidth, (styles[0] as StyleWidthProperty).Width);
				Assert.IsTrue (styles[1] is StyleHeightProperty);
				Assert.AreEqual (expectedHeight, (styles[1] as StyleHeightProperty).Height);
			}

			[Test]
			public void Non_Existent_StyleId()
			{
				const int expectedNumberOfStyles = 0;
				var styles = _proxy.GetStylesById ("nonExistentStyleId");

				Assert.IsNotNull (styles);
				Assert.IsFalse (styles.Any());
				Assert.AreEqual (expectedNumberOfStyles, styles.Count ());
			}
		}

		[TestFixture]
		public class GetStylesByClass
		{
			StyleProxy _proxy;
			
			[TestFixtureSetUp]
			public void TestFixtureSetup()
			{
				const string path = "simple.css";
				
				_proxy = new StyleProxy ();
				_proxy.LoadFromFile (path);
			}
			
			[Test]
			public void Class_Defined_Once()
			{
				const int expectedNumberOfStyles = 2;
				const int expectedWidth = 20;
				const int expectedHeight = 30;
				
				var styles = _proxy.GetStylesByClass ("first-class").ToList();
				
				Assert.IsNotNull (styles);
				Assert.IsTrue (styles.Any());
				Assert.AreEqual (expectedNumberOfStyles, styles.Count ());
				
				Assert.IsTrue (styles[0] is StyleWidthProperty);
				Assert.AreEqual (expectedWidth, (styles[0] as StyleWidthProperty).Width);
				Assert.IsTrue (styles[1] is StyleHeightProperty);
				Assert.AreEqual (expectedHeight, (styles[1] as StyleHeightProperty).Height);
			}
			
			[Test]
			public void Class_Defined_More_Than_Once()
			{
				const int expectedNumberOfStyles = 2;
				const int expectedWidth = 50;
				const int expectedHeight = 100;
				
				var styles = _proxy.GetStylesByClass ("second-class").ToList();
				
				Assert.IsNotNull (styles);
				Assert.IsTrue (styles.Any());
				Assert.AreEqual (expectedNumberOfStyles, styles.Count ());
				
				Assert.IsTrue (styles[0] is StyleWidthProperty);
				Assert.AreEqual (expectedWidth, (styles[0] as StyleWidthProperty).Width);
				Assert.IsTrue (styles[1] is StyleHeightProperty);
				Assert.AreEqual (expectedHeight, (styles[1] as StyleHeightProperty).Height);
			}
			
			[Test]
			public void Non_Existent_Class()
			{
				const int expectedNumberOfStyles = 0;
				var styles = _proxy.GetStylesByClass ("nonExistentStyleId");
				
				Assert.IsNotNull (styles);
				Assert.IsFalse (styles.Any());
				Assert.AreEqual (expectedNumberOfStyles, styles.Count ());
			}
		}
	}
}
