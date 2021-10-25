using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace BigEyes {
	class Downloader {

		public event Action<Stream> OnComplete = null;
		public event Action<Exception> OnError = null;

		public string Url { get; }
		public Stream ResultResponseStream { get; private set; } = null;

		public Downloader(string url) {
			this.Url = url;
		}

		public Downloader(string url, Action<Stream> onComplete, Action<Exception> onError)
		: this(url) {
			this.OnComplete += onComplete;
			this.OnError += onError;
		}

		public void Fetch() {
			try {
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.Url);
				request.Timeout = 5 * 60 * 1000;
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				this.ResultResponseStream = response.GetResponseStream();
				this.OnComplete?.Invoke(this.ResultResponseStream);
			}
			catch (Exception ex) {
				this.OnError?.Invoke(ex);
			}
		}

		public void ParallelFetch() {
			Task task = new Task(Fetch);
			task.Start();
		}
	}
}
