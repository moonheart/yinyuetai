namespace yinyuetai
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPageAddress = new System.Windows.Forms.TextBox();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnCopyLinks = new System.Windows.Forms.Button();
            this.rbHd = new System.Windows.Forms.RadioButton();
            this.rbHc = new System.Windows.Forms.RadioButton();
            this.rbHe = new System.Windows.Forms.RadioButton();
            this.lblTips = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblCurrentTask = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkSingerFolder = new System.Windows.Forms.CheckBox();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.btnChooseSavePath = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.chkCheck = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(14, 34);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAddress.Size = new System.Drawing.Size(882, 354);
            this.txtAddress.TabIndex = 2;
            // 
            // txtPageAddress
            // 
            this.txtPageAddress.Location = new System.Drawing.Point(13, 7);
            this.txtPageAddress.Name = "txtPageAddress";
            this.txtPageAddress.Size = new System.Drawing.Size(335, 21);
            this.txtPageAddress.TabIndex = 0;
            this.txtPageAddress.Text = "http://www.yinyuetai.com/fanclub/mv/1112/toNew";
            // 
            // btnGetInfo
            // 
            this.btnGetInfo.Location = new System.Drawing.Point(354, 6);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(75, 23);
            this.btnGetInfo.TabIndex = 1;
            this.btnGetInfo.Text = "获取信息";
            this.btnGetInfo.UseVisualStyleBackColor = true;
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(676, 13);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 12);
            this.lblMessage.TabIndex = 3;
            // 
            // btnCopyLinks
            // 
            this.btnCopyLinks.Location = new System.Drawing.Point(435, 6);
            this.btnCopyLinks.Name = "btnCopyLinks";
            this.btnCopyLinks.Size = new System.Drawing.Size(75, 23);
            this.btnCopyLinks.TabIndex = 1;
            this.btnCopyLinks.Text = "复制链接";
            this.btnCopyLinks.UseVisualStyleBackColor = true;
            this.btnCopyLinks.Click += new System.EventHandler(this.btnCopyLinks_Click);
            // 
            // rbHd
            // 
            this.rbHd.AutoSize = true;
            this.rbHd.Location = new System.Drawing.Point(4, 3);
            this.rbHd.Name = "rbHd";
            this.rbHd.Size = new System.Drawing.Size(47, 16);
            this.rbHd.TabIndex = 4;
            this.rbHd.Text = "流畅";
            this.rbHd.UseVisualStyleBackColor = true;
            // 
            // rbHc
            // 
            this.rbHc.AutoSize = true;
            this.rbHc.Location = new System.Drawing.Point(57, 3);
            this.rbHc.Name = "rbHc";
            this.rbHc.Size = new System.Drawing.Size(47, 16);
            this.rbHc.TabIndex = 4;
            this.rbHc.Text = "高清";
            this.rbHc.UseVisualStyleBackColor = true;
            // 
            // rbHe
            // 
            this.rbHe.AutoSize = true;
            this.rbHe.Checked = true;
            this.rbHe.Location = new System.Drawing.Point(110, 3);
            this.rbHe.Name = "rbHe";
            this.rbHe.Size = new System.Drawing.Size(47, 16);
            this.rbHe.TabIndex = 4;
            this.rbHe.TabStop = true;
            this.rbHe.Text = "超清";
            this.rbHe.UseVisualStyleBackColor = true;
            // 
            // lblTips
            // 
            this.lblTips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTips.AutoSize = true;
            this.lblTips.Location = new System.Drawing.Point(11, 439);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(125, 12);
            this.lblTips.TabIndex = 5;
            this.lblTips.Text = "支持饭团页面多个视频";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(278, 428);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(618, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // lblCurrentTask
            // 
            this.lblCurrentTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurrentTask.AutoSize = true;
            this.lblCurrentTask.Location = new System.Drawing.Point(524, 407);
            this.lblCurrentTask.Name = "lblCurrentTask";
            this.lblCurrentTask.Size = new System.Drawing.Size(53, 12);
            this.lblCurrentTask.TabIndex = 7;
            this.lblCurrentTask.Text = "当前任务";
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDownload.Location = new System.Drawing.Point(416, 402);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(48, 23);
            this.btnDownload.TabIndex = 8;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(870, 5);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(26, 21);
            this.txtPage.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbHc);
            this.panel1.Controls.Add(this.rbHd);
            this.panel1.Controls.Add(this.rbHe);
            this.panel1.Location = new System.Drawing.Point(517, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(159, 24);
            this.panel1.TabIndex = 10;
            // 
            // chkSingerFolder
            // 
            this.chkSingerFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSingerFolder.AutoSize = true;
            this.chkSingerFolder.Checked = true;
            this.chkSingerFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSingerFolder.Location = new System.Drawing.Point(278, 406);
            this.chkSingerFolder.Name = "chkSingerFolder";
            this.chkSingerFolder.Size = new System.Drawing.Size(132, 16);
            this.chkSingerFolder.TabIndex = 11;
            this.chkSingerFolder.Text = "自动建立歌手文件夹";
            this.chkSingerFolder.UseVisualStyleBackColor = true;
            // 
            // txtSavePath
            // 
            this.txtSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSavePath.Location = new System.Drawing.Point(71, 403);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(145, 21);
            this.txtSavePath.TabIndex = 12;
            this.txtSavePath.Text = "E:\\MVDownload";
            this.txtSavePath.TextChanged += new System.EventHandler(this.txtSavePath_TextChanged);
            // 
            // lblSavePath
            // 
            this.lblSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.Location = new System.Drawing.Point(12, 407);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(53, 12);
            this.lblSavePath.TabIndex = 5;
            this.lblSavePath.Text = "保存路径";
            // 
            // btnChooseSavePath
            // 
            this.btnChooseSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChooseSavePath.Location = new System.Drawing.Point(224, 402);
            this.btnChooseSavePath.Name = "btnChooseSavePath";
            this.btnChooseSavePath.Size = new System.Drawing.Size(48, 23);
            this.btnChooseSavePath.TabIndex = 8;
            this.btnChooseSavePath.Text = "选择";
            this.btnChooseSavePath.UseVisualStyleBackColor = true;
            this.btnChooseSavePath.Click += new System.EventHandler(this.btnChooseSavePath_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(470, 402);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(48, 23);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkCheck
            // 
            this.chkCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCheck.AutoSize = true;
            this.chkCheck.Location = new System.Drawing.Point(164, 435);
            this.chkCheck.Name = "chkCheck";
            this.chkCheck.Size = new System.Drawing.Size(108, 16);
            this.chkCheck.TabIndex = 14;
            this.chkCheck.Text = "仅检查已有文件";
            this.chkCheck.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 463);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkCheck);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.chkSingerFolder);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.btnChooseSavePath);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lblCurrentTask);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblSavePath);
            this.Controls.Add(this.lblTips);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnCopyLinks);
            this.Controls.Add(this.btnGetInfo);
            this.Controls.Add(this.txtPageAddress);
            this.Controls.Add(this.txtAddress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(924, 501);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "音悦台网页视频批量获取工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPageAddress;
        private System.Windows.Forms.Button btnGetInfo;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnCopyLinks;
        private System.Windows.Forms.RadioButton rbHd;
        private System.Windows.Forms.RadioButton rbHc;
        private System.Windows.Forms.RadioButton rbHe;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblCurrentTask;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkSingerFolder;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.Button btnChooseSavePath;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox chkCheck;
        private System.Windows.Forms.Button button1;
    }
}

