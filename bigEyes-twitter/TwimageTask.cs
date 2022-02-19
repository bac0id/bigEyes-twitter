using System;
using System.Drawing;

namespace BigEyes {
	/// <summary>
	/// 推特图片
	/// </summary>
	class TwimageTask {
		public event Action OnComplete = null;
		public event Action<Exception> OnError = null;

		private readonly TwimageUrlParser parser;

		public Image Image { get; private set; } = null;
		public string Id => this.parser.Id; 
		public string Extension=> this.parser.Extension; 
		public string FileName  => this.parser.FileName; 
		public string Url => this.parser.Url;

		public TwimageTask(string url) {
			try {
				this.parser = new TwimageUrlParser(url);
			}
			catch (ArgumentException argEx) {
				this.OnError?.Invoke(argEx);
			}
		}

		public TwimageTask(TwimageUrlParser parser) {
			this.parser = parser;
		}

		/// <summary>
		/// 开始下载图片
		/// </summary>
		public void Fetch() {
			Downloader dl = new Downloader(
				this.parser.Url,
				onComplete => {
					this.Image = Image.FromStream(onComplete);
					this.OnComplete.Invoke();
				},
				onException => {
					//this.OnError.Invoke(onException);
				}
			);
			dl.ParallelFetch();
		}


		///// <summary>
		///// 保存图片
		///// </summary>
		///// <param name="url">Url</param>
		//[Obsolete]
		//private void SaveImage(object url) {
		//	//更新任务数
		//	UpdateThreadNum(1);
		//	//多线程中传递的参数智能是object类型，需强制转换
		//	string str = (string)url;
		//	//Debug.Print("downloading " + str);
		//	//得到图片
		//	Image img = GetImage(str);
		//	//图片的绝对路径
		//	string saveFile = string.Format("{0}\\{1}", path, GetImageName(str));
		//	//保存图片到路径
		//	img.Save(saveFile);
		//	//Debug.Print("complete");
		//	//更新任务数
		//	UpdateThreadNum(-1);
		//}

		////输入：https://pbs.twimg.com/media/ABCDEabcde12345.jpg:orig
		////输出：ABCDEabcde12345.jpg
		///// <summary>
		///// 返回图片名称
		///// </summary>
		///// <param name="url">Url</param>
		//[Obsolete]
		//private string GetImageName(string url) {
		//	int p = url.Length - 1;
		//	char flag = '\0';
		//	//逆序寻找符号'?'或'/'或':'，
		//	while (p >= 0) {
		//		if (url[p] == '?' || url[p] == '/' || url[p] == ':') {
		//			//标记找到的符号
		//			flag = url[p];
		//			break;
		//		}
		//		--p;
		//	}
		//	//找到的符号是'/'，说明图片不带参数，直接返回从p到末尾的子字符串
		//	if (flag == '/') {
		//		return url.Substring(p);
		//	} else {
		//		int end = --p;
		//		while (p >= 0) {
		//			if (url[p] == '/') {
		//				break;
		//			}
		//			--p;
		//		}
		//		return url.Substring(p, end - p + 1);
		//	}
		//}
	}
}
