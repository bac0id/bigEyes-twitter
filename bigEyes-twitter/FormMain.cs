using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BigEyes {
	public partial class FormMain : Form {

		private const string Filename_Config = "Setting.txt";
		private const string Filename_Log = "Log.txt";
		private const string Filename_Failed_Tasks = "Failed.txt";

		// 保存图片的路径
		private string savePath;

		private QueueManager qm;
		private LogWriter logWriter = new LogWriter(Filename_Log);
		private IImageSaver saver;

		public FormMain() {
			this.InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;

			this.LoadOrInitConfig();

			this.saver = new ImageSaver(this.savePath);

			this.qm = new QueueManager(Filename_Failed_Tasks);
			this.qm.OnTaskCountChanged += (cnt) => this.lblTaskNum.Text = cnt.ToString();
			if (true) {
				RestartFailedTasks();
			}
		}

		private void LoadOrInitConfig() {
			// 读取设置路径
			if (File.Exists(Filename_Config) == false) {
				InitConfig();
			}
			LoadConfig();
		}

		/// <summary>
		/// 读取配置文件
		/// </summary>
		private void LoadConfig() {
			StreamReader sr = new StreamReader(Filename_Config);
			//只读1行作为保存路径
			this.savePath = sr.ReadLine();
			sr.Close();
		}

		/// <summary>
		/// 初始化配置文件
		/// </summary>
		private void InitConfig() {
			string savePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			StreamWriter sw = new StreamWriter(Filename_Config);
			sw.WriteLine(savePath);
			sw.Close();
			//byte[] array = Encoding.Default.GetBytes(path);
			//FileStream fs = new FileStream(Filename_Config, FileMode.Create);
			//fs.Write(array, 0, array.Length);
			//fs.Close();
		}

		private void RestartFailedTasks() {
			foreach (string str in qm.Tasks) {
				TryAddNewTask(str);
			}
		}

		private void NotifyIllegalInput() {
			MessageBox.Show("当前剪贴板内容不是有效的输入！No legal url found in clipboard!");
		}

		private void btnOpen_Click(object sender, EventArgs e) {
			if (Clipboard.ContainsText()) {
				string str = Clipboard.GetText();
				TwimageUrlParser parser = new TwimageUrlParser(str);
				try {
					Process.Start(parser.Url);
				}
				catch (ArgumentException) {
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

		private void TryAddNewTask(string str) {
			try {
				TwimageTask tw = new TwimageTask(str);
				tw.OnComplete += () => {
					this.logWriter.WriteLine("O", tw.FileName);
					this.saver.Save(tw.Image, tw.FileName);
					this.qm.Remove(tw.Url);
				};
				this.qm.Add(tw.Url);
				tw.Fetch();
			}
			catch (ArgumentException ex) {
				NotifyIllegalInput();
			}
			catch (Exception ex) {
				this.logWriter.WriteLine("-", ex.Message + ex.StackTrace);
			}

		}

		private void ckbTop_CheckedChanged(object sender, EventArgs e) {
			this.TopMost = ckbTop.Checked;
		}

		private void btnOptions_Click(object sender, EventArgs e) {
			MessageBox.Show("设置保存图片路径。Select an path for saving images.");
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			if (dialog.ShowDialog() == DialogResult.OK) {
				savePath = dialog.SelectedPath;
				using (StreamWriter sw = new StreamWriter(Filename_Config, true)) {
					sw.WriteLine(savePath);
				}
			}
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
			logWriter.Close();
			qm.SaveToFile();
		}

		private void btnCopyUrl_Click(object sender, EventArgs e) {
			if (Clipboard.ContainsText()) {
				string str = Clipboard.GetText();
				TwimageUrlParser parser = new TwimageUrlParser(str);
				try {
					Clipboard.SetText(parser.Url);
				}
				catch (ArgumentException) {
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
