namespace yinyuetai
{
    partial class MvInfoView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pbThumb = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSingerName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumb)).BeginInit();
            this.SuspendLayout();
            // 
            // pbThumb
            // 
            this.pbThumb.Location = new System.Drawing.Point(3, 3);
            this.pbThumb.Name = "pbThumb";
            this.pbThumb.Size = new System.Drawing.Size(120, 67);
            this.pbThumb.TabIndex = 0;
            this.pbThumb.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(129, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(66, 27);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "标题";
            // 
            // lblSingerName
            // 
            this.lblSingerName.AutoSize = true;
            this.lblSingerName.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSingerName.Location = new System.Drawing.Point(129, 39);
            this.lblSingerName.Name = "lblSingerName";
            this.lblSingerName.Size = new System.Drawing.Size(66, 19);
            this.lblSingerName.TabIndex = 1;
            this.lblSingerName.Text = "歌手名";
            // 
            // MvInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSingerName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbThumb);
            this.Name = "MvInfoView";
            this.Size = new System.Drawing.Size(558, 72);
            ((System.ComponentModel.ISupportInitialize)(this.pbThumb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbThumb;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSingerName;
    }
}
