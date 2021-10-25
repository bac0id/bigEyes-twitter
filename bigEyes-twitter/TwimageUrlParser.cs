using System;

namespace BigEyes {

	/* https://pbs.twimg.com/media/ABCDEabcde12345.jpg:orig
	 * https://pbs.twimg.com/media/ABCDEabcde12345?format=jpg&name=medium
	 * 012345678901234567890123456789012345678901234567890123456789
	 * ^0        ^10       ^20       ^30       ^40       ^50
	 */

	class TwimageUrlParser {
		private const string ImagePrefix = "https://pbs.twimg.com/media/";
		private const string OriginalImageSuffix = ":orig";

		private string id = null;
		private string extension = null;

		public string Url { get; private set; }

		public TwimageUrlParser(string url) {
			if (url.StartsWith(ImagePrefix) == false) {
				throw new ArgumentException();
			}
			this.Url = url;
			//如果不是原图地址
			if (url.EndsWith(OriginalImageSuffix) == false) {
				this.Url = this.ToOriginalUrl();
			}
		}

		/// <summary>
		/// 文件号（不含后缀名）
		/// </summary>
		public string Id {
			get {
				if (this.id == null) {
					this.id = this.Url.Substring(28, 15);
				}
				//返回：ABCDEabcde12345
				return this.id;
			}
		}

		/// <summary>
		/// 后缀名（jpg或png）
		/// </summary>
		public string Extension {
			get {
				if (this.extension == null) {
					this.extension = this.Url.Substring(51, 3);
				}
				return this.extension;
			}
		}

		/// <summary>
		/// 文件名（含后缀）
		/// </summary>
		public string FileName {
			get => $"{this.Id}.{this.Extension}";
		}

		private string ToOriginalUrl() {
			//输入：https://pbs.twimg.com/media/ABCDEabcde12345?format=jpg&name=small
			//输出：https://pbs.twimg.com/media/ABCDEabcde12345.jpg:orig
			return $"{ImagePrefix}{this.FileName}{OriginalImageSuffix}";
		}
	}
}
