using System;
using System.Collections.Specialized;
using System.Web;

namespace BigEyes.Core {

	/* https://pbs.twimg.com/media/ABCDEabcde12345.jpg:orig
	 * https://pbs.twimg.com/media/ABCDEabcde12345?format=jpg&name=medium
	 * 012345678901234567890123456789012345678901234567890123456789
	 * ^0        ^10       ^20       ^30       ^40       ^50
	 */

	public class TwimageUrlParser {
		private const string ImagePrefix = "https://pbs.twimg.com/media/";
		private const string OriginalImageSuffix = ":orig";

		private Uri uri;

		public TwimageUrlParser(string url) {
			this.SetUrl(url);
		}

		public void SetUrl(string url) {
			this.uri = new Uri(url);

			// Docs: https://learn.microsoft.com/en-us/dotnet/api/system.io.fileinfo?view=netframework-4.8
			string[] uriSegments = this.uri.Segments;
			string lastSegment = uriSegments[uriSegments.Length - 1];

			// if input is original url
			if (lastSegment.EndsWith(":orig")) {
				int indexOfDot = lastSegment.IndexOf('.');
				this.Name = lastSegment.Substring(0, indexOfDot + 4);
				this.Id = lastSegment.Substring(0, indexOfDot);
				this.Extension = lastSegment.Substring(indexOfDot, 4);
			} else {
				this.Id = lastSegment;

				string queries = this.uri.Query;
				NameValueCollection queriesCollection = HttpUtility.ParseQueryString(queries);
				string extension = "." + queriesCollection.Get("format");
				this.Extension = extension;

				this.Name = this.Id + this.Extension;
			}
		}

		/// <summary>
		/// Image ID (without Extension).
		/// <para>
		/// Example: <c>ABCDEabcde12345</c>.
		/// </para>
		/// </summary>
		public string Id { get; private set; }

		/// <summary>
		/// Extension.
		/// <para>
		///	Should be <c>".jpg"</c> or <c>".png"</c>.
		/// </para>
		/// </summary>
		public string Extension { get; private set; }

		/// <summary>
		/// Image ID (without Extension).
		/// <para>
		/// Example: <c>ABCDEabcde12345.png</c>.
		/// </para>
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Url of original image.
		/// <para>
		/// Example: <c>https://pbs.twimg.com/media/ABCDEabcde12345.jpg:orig</c>
		/// </para>
		/// </summary>
		public string OriginalImageUrl => ImagePrefix + this.Name + OriginalImageSuffix;
		
	}
}
