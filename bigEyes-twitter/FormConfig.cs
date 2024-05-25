using System;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using BigEyes.Properties;

namespace BigEyes
{
	public partial class FormConfig : Form {
		public FormConfig() {
			InitializeComponent();
			this.LoadConfigView();
		}

		private void LoadConfigView() {
			this.textBoxSavingPath.Text = Settings.Default.SavingPath;
			this.checkBoxTopMost.Checked = Settings.Default.TopMost;
			this.checkBoxRetryFailedDownloads.Checked = Settings.Default.RetryFailedDownloads;

			this.checkBoxUseProxy.Checked = Settings.Default.UseProxy;
			this.textBoxProxyAddress.Text = Settings.Default.ProxyAddress;
			this.checkBoxUseProxyCredential.Checked = Settings.Default.UseProxyCredential;
			this.textBoxProxyUsername.Text = Settings.Default.ProxyUsername;
			this.textBoxProxyPassword.Text = Settings.Default.ProxyPassword;
		}

		private void SaveConfig() {
			Settings.Default.SavingPath = this.textBoxSavingPath.Text;
			Settings.Default.TopMost = this.checkBoxTopMost.Checked;
			Settings.Default.RetryFailedDownloads = this.checkBoxRetryFailedDownloads.Checked;

			Settings.Default.UseProxy = this.checkBoxUseProxy.Checked;
			Settings.Default.ProxyAddress = this.textBoxProxyAddress.Text;
			Settings.Default.UseProxyCredential = this.checkBoxUseProxyCredential.Checked;
			Settings.Default.ProxyUsername = this.textBoxProxyUsername.Text;
			Settings.Default.ProxyPassword = this.textBoxProxyPassword.Text;

			Settings.Default.Save();
		}

		private void buttonSelectSavingPath_Click(object sender, EventArgs e) {
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			if (dialog.ShowDialog() == DialogResult.OK) {
				textBoxSavingPath.Text = dialog.SelectedPath;
			}
		}


			private void buttonConfirm_Click(object sender, EventArgs e) {
			this.SaveConfig();
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}
