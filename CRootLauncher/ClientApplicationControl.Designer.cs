namespace CRootLauncher
{
    partial class ClientApplicationControl
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbFileName = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.Location = new System.Drawing.Point(60, 6);
            this.lbFileName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lbFileName.MaximumSize = new System.Drawing.Size(180, 12);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(65, 12);
            this.lbFileName.TabIndex = 0;
            this.lbFileName.Text = "lbFileName";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(6, 6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(48, 48);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoEllipsis = true;
            this.lbDescription.AutoSize = true;
            this.lbDescription.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbDescription.Location = new System.Drawing.Point(60, 24);
            this.lbDescription.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbDescription.MaximumSize = new System.Drawing.Size(180, 12);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(179, 12);
            this.lbDescription.TabIndex = 2;
            this.lbDescription.Text = "lbDescriptionlbDescriptionlbDescription";
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbVersion.Location = new System.Drawing.Point(60, 42);
            this.lbVersion.MaximumSize = new System.Drawing.Size(180, 12);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(59, 12);
            this.lbVersion.TabIndex = 3;
            this.lbVersion.Text = "lbVersion";
            // 
            // ClientApplicationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lbFileName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ClientApplicationControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(250, 60);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbVersion;
    }
}
