using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BigEyes {
	public partial class FormMain : Form {

		private const string FILENAME_SETTING = "Setting.txt";
		private const string FILENAME_LOG = "Log.txt";
		private int TaskNum {
			get {
				return this._taskNum;
			}
			set {
				this._taskNum = value;
				this.lbl1.Text = _taskNum.ToString();
			}
		}
		private string path;
		private int _taskNum = 0;
		private LogWriter logWriter = new LogWriter(FILENAME_LOG);
		private IImageSaver saver;

		public FormMain() {
			this.InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;
			this.LoadConfig();
			this.saver = new ImageSaver(this.path);
		}

		/// <summary>
		/// 读取设置
		/// </summary>
		private void LoadConfig() {
			//读取路径设置
			if (File.Exists(FILENAME_SETTING)) {
				StreamReader sr = new StreamReader(FILENAME_SETTING);
				//只读1行作为保存路径
				this.path = sr.ReadLine();
				sr.Close();
			} else {
				InitConfig();
			}
		}

		private void InitConfig() {
			this.path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			byte[] array = Encoding.Default.GetBytes(path);
			FileStream fs = new FileStream(FILENAME_SETTING, FileMode.Create);
			fs.Write(array, 0, array.Length);
			fs.Close();
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
				try {
					Twimage tw = new Twimage(str);
					tw.OnComplete += () => {
						this.logWriter.WriteLine("OK", tw.FileName);
						this.saver.Save(tw.Image, tw.FileName);
						this.TaskNum--;
					};
					tw.Fetch();
					this.TaskNum++;
				}
				catch (ArgumentException ex) {
					NotifyIllegalInput();
				}
				catch (Exception ex) {
					this.logWriter.WriteLine("Ex", ex.Message);
				}
			} else {
				NotifyIllegalInput();
			}
		}

		private void ckbTop_CheckedChanged(object sender, EventArgs e) {
			this.TopMost = ckbTop.Checked;
		}

		private void btnOptions_Click(object sender, EventArgs e) {
			MessageBox.Show("设置保存图片路径。Select an path for saving images.");
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			if (dialog.ShowDialog() == DialogResult.OK) {
				path = dialog.SelectedPath;
				using (StreamWriter sw = new StreamWriter(FILENAME_SETTING, true)) {
					sw.WriteLine(path);
				}
			}
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
			logWriter.Close();
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
			Process.Start(FILENAME_LOG);
		}
	}
}
