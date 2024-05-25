using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using BigEyes.Component;
using BigEyes.Core;
using BigEyes.Properties;

namespace BigEyes {
	public partial class FormMain : Form {

		private const string Filename_Log = "Log.txt";
		private const string Filename_Failed_Tasks = "Failed.txt";

		private LogWriter logWriter = new LogWriter(Filename_Log);

		private IImageSaver saver;
		private HttpClient httpClient;
		private QueueManager queueManager;

		public FormMain() {
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;

			LoadConfig();


			if (Settings.Default.RetryFailedDownloads) {
				RestartFailedTasks();
			}
		}

		private void LoadConfig() {
			if (string.IsNullOrWhiteSpace(Settings.Default.SavingPath)) {
				saver = new ImageSaver(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
			} else {
				saver = new ImageSaver(Settings.Default.SavingPath);
			}
			TopMost = Settings.Default.TopMost;

			queueManager = new QueueManager(Filename_Failed_Tasks);
			queueManager.OnTaskCountChanged += (cnt) => lblTaskNum.Text = cnt.ToString();


			WebProxy proxy = null;
			if (Settings.Default.UseProxy) {

				NetworkCredential credentials = null;
				if (Settings.Default.UseProxyCredential) {
					credentials = new NetworkCredential(
						userName: Settings.Default.ProxyUsername,
						password: Settings.Default.ProxyPassword);
				}

				proxy = new WebProxy {
					Address = new Uri(Settings.Default.ProxyAddress),
					BypassProxyOnLocal = false,
					UseDefaultCredentials = false,

					// *** These creds are given to the proxy server, not the web server ***
					Credentials = credentials
				};
			}

			// Now create a client handler which uses that proxy
			HttpClientHandler httpClientHandler = new HttpClientHandler {
				Proxy = proxy,
				UseProxy = proxy != null,
			};
			this.httpClient = new HttpClient(httpClientHandler, disposeHandler: true);
		}

		private void RestartFailedTasks() {
			foreach (string str in queueManager.Tasks) {
				TryAddNewTask(str);
			}
		}

		private void NotifyIllegalInput() {
			MessageBox.Show("No valid url found in clipboard! 当前剪贴板内容不是有效的输入！");
		}

		private void btnOpen_Click(object sender, EventArgs e) {
			if (Clipboard.ContainsText()) {
				string str = Clipboard.GetText();
				TwimageUrlParser parser = new TwimageUrlParser(str);
				try {
					Process.Start(parser.OriginalImageUrl);
				} catch (ArgumentException) {
					NotifyIllegalInput();
				}
			} else {
				NotifyIllegalInput();
			}
		}

		private void btnSave_Click(object sender, EventArgs e) {
			if (Clipboard.ContainsText()) {
				string str = Clipboard.GetText();
				TryAddNewTask(str);
			} else {
				NotifyIllegalInput();
			}
		}

		private async void TryAddNewTask(string url) {
			try {
				TwimageUrlParser parser = new TwimageUrlParser(url);

				string originalImageUrl = parser.OriginalImageUrl;

				queueManager.Add(originalImageUrl);

				HttpResponseMessage responseMessage = await this.httpClient.GetAsync(originalImageUrl);
				Stream stream = await responseMessage.Content.ReadAsStreamAsync();
				Image image = Image.FromStream(stream);
				saver.Save(image, parser.Name);

				queueManager.Remove(originalImageUrl);

				//TwimageTask tw = new TwimageTask(url);
				//tw.OnComplete += () => {
				//	this.logWriter.WriteLine("O", tw.FileName);
				//	this.saver.Save(tw.Image, tw.FileName);
				//	this.queueManager.Remove(tw.Url);
				//};
				//this.queueManager.Add(tw.Url);
				//tw.Fetch();
			} catch (ArgumentException ex) {
				NotifyIllegalInput();
			} catch (Exception ex) {
				logWriter.WriteLine("-", ex.Message + ex.StackTrace);
			}

		}

		private void btnOptions_Click(object sender, EventArgs e) {
			var result = ShowDialogForm(new FormConfig());
			if (result == DialogResult.OK) {
				this.LoadConfig();
			}
		}

		private DialogResult ShowDialogForm(Form form) {
			// Save TopMost field
			bool topMost = this.TopMost;
			this.TopMost = false;

			var result = form.ShowDialog(this);

			// Retrieve TopMost field
			this.TopMost = topMost;

			return result;
		}


		private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
			logWriter.Close();
			queueManager.SaveToFile();
		}

		private void btnCopyUrl_Click(object sender, EventArgs e) {
			if (Clipboard.ContainsText()) {
				string str = Clipboard.GetText();
				TwimageUrlParser parser = new TwimageUrlParser(str);
				try {
					Clipboard.SetText(parser.OriginalImageUrl);
				} catch (ArgumentException) {
					NotifyIllegalInput();
				}
			} else {
				NotifyIllegalInput();
			}
		}

		private void btnLog_Click(object sender, EventArgs e) {
			Process.Start(Filename_Log);
		}
	}
}
