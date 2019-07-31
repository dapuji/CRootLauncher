namespace CRootLauncher
{
    partial class ConfigurationControl
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
            this.txtResourceUri = new System.Windows.Forms.TextBox();
            this.txtRedirectUri = new System.Windows.Forms.TextBox();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAuthority = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAuthorize = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResourceUri
            // 
            this.txtResourceUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResourceUri.Location = new System.Drawing.Point(89, 33);
            this.txtResourceUri.Name = "txtResourceUri";
            this.txtResourceUri.Size = new System.Drawing.Size(405, 21);
            this.txtResourceUri.TabIndex = 17;
            // 
            // txtRedirectUri
            // 
            this.txtRedirectUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRedirectUri.Location = new System.Drawing.Point(89, 87);
            this.txtRedirectUri.Name = "txtRedirectUri";
            this.txtRedirectUri.Size = new System.Drawing.Size(405, 21);
            this.txtRedirectUri.TabIndex = 18;
            // 
            // txtClientId
            // 
            this.txtClientId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientId.Location = new System.Drawing.Point(89, 60);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(405, 21);
            this.txtClientId.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "RedirectUri:";
            // 
            // txtAuthority
            // 
            this.txtAuthority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthority.Location = new System.Drawing.Point(89, 6);
            this.txtAuthority.Name = "txtAuthority";
            this.txtAuthority.Size = new System.Drawing.Size(405, 21);
            this.txtAuthority.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "ClientId:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "ResourceUri:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "Authority:";
            // 
            // btnAuthorize
            // 
            this.btnAuthorize.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAuthorize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAuthorize.FlatAppearance.BorderSize = 0;
            this.btnAuthorize.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAuthorize.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Info;
            this.btnAuthorize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuthorize.Location = new System.Drawing.Point(8, 134);
            this.btnAuthorize.Name = "btnAuthorize";
            this.btnAuthorize.Size = new System.Drawing.Size(75, 23);
            this.btnAuthorize.TabIndex = 21;
            this.btnAuthorize.Text = "Authorize";
            this.btnAuthorize.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Info;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(89, 134);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // ConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAuthorize);
            this.Controls.Add(this.txtResourceUri);
            this.Controls.Add(this.txtRedirectUri);
            this.Controls.Add(this.txtClientId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAuthority);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ConfigurationControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(500, 310);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResourceUri;
        private System.Windows.Forms.TextBox txtRedirectUri;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAuthority;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAuthorize;
        private System.Windows.Forms.Button btnReset;
    }
}
