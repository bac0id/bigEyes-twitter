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
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.btnOpen = new System.Windows.Forms.Button();
			this.ckbTop = new System.Windows.Forms.CheckBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnOptions = new System.Windows.Forms.Button();
			this.lblTaskNum = new System.Windows.Forms.Label();
			this.btnLog = new System.Windows.Forms.Button();
			this.lbl2 = new System.Windows.Forms.Label();
			this.btnCopyUrl = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnOpen.Location = new System.Drawing.Point(12, 71);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(50, 28);
			this.btnOpen.TabIndex = 2;
			this.btnOpen.Text = "访问";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// ckbTop
			// 
			this.ckbTop.AutoSize = true;
			this.ckbTop.Checked = true;
			this.ckbTop.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckbTop.Location = new System.Drawing.Point(11, 143);
			this.ckbTop.Margin = new System.Windows.Forms.Padding(2);
			this.ckbTop.Name = "ckbTop";
			this.ckbTop.Size = new System.Drawing.Size(68, 18);
			this.ckbTop.TabIndex = 4;
			this.ckbTop.Text = "在最前";
			this.ckbTop.UseVisualStyleBackColor = true;
			this.ckbTop.CheckedChanged += new System.EventHandler(this.ckbTop_CheckedChanged);
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnSave.Location = new System.Drawing.Point(12, 12);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(106, 28);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "下载至本地";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnOptions
			// 
			this.btnOptions.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnOptions.Location = new System.Drawing.Point(68, 110);
			this.btnOptions.Name = "btnOptions";
			this.btnOptions.Size = new System.Drawing.Size(50, 28);
			this.btnOptions.TabIndex = 3;
			this.btnOptions.Text = "设置";
			this.btnOptions.UseVisualStyleBackColor = true;
			this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
			// 
			// lbl1
			// 
			this.lblTaskNum.BackColor = System.Drawing.SystemColors.Control;
			this.lblTaskNum.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblTaskNum.Location = new System.Drawing.Point(62, 48);
			this.lblTaskNum.Name = "lbl1";
			this.lblTaskNum.Size = new System.Drawing.Size(56, 17);
			this.lblTaskNum.TabIndex = 5;
			this.lblTaskNum.Text = "0";
			this.lblTaskNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnLog
			// 
			this.btnLog.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnLog.Location = new System.Drawing.Point(12, 110);
			this.btnLog.Name = "btnLog";
			this.btnLog.Size = new System.Drawing.Size(50, 28);
			this.btnLog.TabIndex = 4;
			this.btnLog.Text = "日志";
			this.btnLog.UseVisualStyleBackColor = true;
			this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
			// 
			// lbl2
			// 
			this.lbl2.AutoSize = true;
			this.lbl2.BackColor = System.Drawing.SystemColors.Control;
			this.lbl2.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lbl2.Location = new System.Drawing.Point(12, 48);
			this.lbl2.Name = "lbl2";
			this.lbl2.Size = new System.Drawing.Size(44, 17);
			this.lbl2.TabIndex = 6;
			this.lbl2.Text = "队列:";
			this.lbl2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnCopyUrl
			// 
			this.btnCopyUrl.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnCopyUrl.Location = new System.Drawing.Point(68, 71);
			this.btnCopyUrl.Name = "btnCopyUrl";
			this.btnCopyUrl.Size = new System.Drawing.Size(50, 28);
			this.btnCopyUrl.TabIndex = 7;
			this.btnCopyUrl.Text = "复制";
			this.btnCopyUrl.UseVisualStyleBackColor = true;
			this.btnCopyUrl.Click += new System.EventHandler(this.btnCopyUrl_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(130, 172);
			this.Controls.Add(this.btnCopyUrl);
			this.Controls.Add(this.lbl2);
			this.Controls.Add(this.btnLog);
			this.Controls.Add(this.lblTaskNum);
			this.Controls.Add(this.btnOptions);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.ckbTop);
			this.Controls.Add(this.btnOpen);
			this.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BigEyes";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.CheckBox ckbTop;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnOptions;
		private System.Windows.Forms.Label lblTaskNum;
		private System.Windows.Forms.Button btnLog;
		private System.Windows.Forms.Label lbl2;
		private System.Windows.Forms.Button btnCopyUrl;
	}
}

