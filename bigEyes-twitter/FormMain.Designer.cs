namespace BigEyes
{
	partial class FormMain
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnOptions = new System.Windows.Forms.Button();
			this.lblTaskNum = new System.Windows.Forms.Label();
			this.btnLog = new System.Windows.Forms.Button();
			this.lbl2 = new System.Windows.Forms.Label();
			this.btnCopyUrl = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnOpen.Location = new System.Drawing.Point(2, 1);
			this.btnOpen.Margin = new System.Windows.Forms.Padding(0);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(56, 27);
			this.btnOpen.TabIndex = 1;
			this.btnOpen.Text = "Open";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += this.btnOpen_Click;
			// 
			// btnSave
			// 
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnSave.Location = new System.Drawing.Point(0, 0);
			this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(144, 60);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Download";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += this.btnSave_Click;
			// 
			// btnOptions
			// 
			this.btnOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnOptions.AutoSize = true;
			this.btnOptions.Location = new System.Drawing.Point(62, 30);
			this.btnOptions.Margin = new System.Windows.Forms.Padding(0);
			this.btnOptions.Name = "btnOptions";
			this.btnOptions.Size = new System.Drawing.Size(56, 27);
			this.btnOptions.TabIndex = 4;
			this.btnOptions.Text = "Config";
			this.btnOptions.UseVisualStyleBackColor = true;
			this.btnOptions.Click += this.btnOptions_Click;
			// 
			// lblTaskNum
			// 
			this.lblTaskNum.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.lblTaskNum.BackColor = System.Drawing.SystemColors.Control;
			this.lblTaskNum.Location = new System.Drawing.Point(90, 65);
			this.lblTaskNum.Name = "lblTaskNum";
			this.lblTaskNum.Size = new System.Drawing.Size(42, 19);
			this.lblTaskNum.TabIndex = 5;
			this.lblTaskNum.Text = "0";
			this.lblTaskNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnLog
			// 
			this.btnLog.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnLog.Location = new System.Drawing.Point(2, 30);
			this.btnLog.Margin = new System.Windows.Forms.Padding(0);
			this.btnLog.Name = "btnLog";
			this.btnLog.Size = new System.Drawing.Size(56, 27);
			this.btnLog.TabIndex = 3;
			this.btnLog.Text = "Log";
			this.btnLog.UseVisualStyleBackColor = true;
			this.btnLog.Click += this.btnLog_Click;
			// 
			// lbl2
			// 
			this.lbl2.AutoSize = true;
			this.lbl2.BackColor = System.Drawing.SystemColors.Control;
			this.lbl2.Location = new System.Drawing.Point(12, 65);
			this.lbl2.Name = "lbl2";
			this.lbl2.Size = new System.Drawing.Size(88, 17);
			this.lbl2.TabIndex = 6;
			this.lbl2.Text = "Downloading:";
			this.lbl2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnCopyUrl
			// 
			this.btnCopyUrl.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnCopyUrl.Location = new System.Drawing.Point(62, 1);
			this.btnCopyUrl.Margin = new System.Windows.Forms.Padding(0);
			this.btnCopyUrl.Name = "btnCopyUrl";
			this.btnCopyUrl.Size = new System.Drawing.Size(56, 27);
			this.btnCopyUrl.TabIndex = 2;
			this.btnCopyUrl.Text = "Copy";
			this.btnCopyUrl.UseVisualStyleBackColor = true;
			this.btnCopyUrl.Click += this.btnCopyUrl_Click;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.btnCopyUrl, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnOptions, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnLog, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnOpen, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 87);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(120, 58);
			this.tableLayoutPanel1.TabIndex = 7;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(144, 157);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.lbl2);
			this.Controls.Add(this.lblTaskNum);
			this.Controls.Add(this.btnSave);
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BigEyes";
			this.TopMost = true;
			this.FormClosing += this.FormMain_FormClosing;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnOptions;
		private System.Windows.Forms.Label lblTaskNum;
		private System.Windows.Forms.Button btnLog;
		private System.Windows.Forms.Label lbl2;
		private System.Windows.Forms.Button btnCopyUrl;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}

