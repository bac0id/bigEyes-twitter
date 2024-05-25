using BigEyes.Core;

namespace BigEyes.Test {
	[TestClass]
	public class TwimageUrlParserTest {

		[TestMethod]
		public void Test1() {
			string url = "https://pbs.twimg.com/media/ABCDEabcde12345?format=jpg&name=medium";
			string id = "ABCDEabcde12345";
			string ext = ".jpg";
			string name = id + ext;
			string original = "https://pbs.twimg.com/media/ABCDEabcde12345.jpg:orig";

			TwimageUrlParser parser = new TwimageUrlParser(url);

			Assert.AreEqual(id, parser.Id);
			Assert.AreEqual(ext, parser.Extension);
			Assert.AreEqual(name, parser.Name);
			Assert.AreEqual(original, parser.OriginalImageUrl);
		}

		[TestMethod]
		public void Test2() {
			string original = "https://pbs.twimg.com/media/ABCDEabcde12345.jpg:orig";
			string id = "ABCDEabcde12345";
			string ext = ".jpg";
			string name = id + ext;

			TwimageUrlParser parser = new TwimageUrlParser(original);

			Assert.AreEqual(id, parser.Id);
			Assert.AreEqual(ext, parser.Extension);
			Assert.AreEqual(name, parser.Name);
			Assert.AreEqual(original, parser.OriginalImageUrl);
		}
	}
}
