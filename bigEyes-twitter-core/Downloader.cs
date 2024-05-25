using System.Net;

namespace BigEyes.Core {
	class Downloader {

		public event Action<Stream> OnComplete;
		public event Action<Exception> OnError;

		public string Url { get; }
		public Stream ResponseStream { get; private set; }

		public Downloader(string url) {
			this.Url = url;
		}

		public Downloader(string url, Action<Stream> onComplete, Action<Exception> onError)
		: this(url) {
			this.OnComplete += onComplete;
			this.OnError += onError;
		}

		public void StartDownload() {
			try {
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.Url);
				request.Timeout = 5 * 60 * 1000;
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				this.ResponseStream = response.GetResponseStream();
				this.OnComplete?.Invoke(this.ResponseStream);
			}
			catch (Exception ex) {
				this.OnError?.Invoke(ex);
				throw ex;
			}
		}

		public async void StartDownloadAsync() {
			await Task.Run(StartDownload);
		}
	}
}
