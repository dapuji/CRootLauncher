namespace CRootLauncher
{
    partial class AuthorizationControl
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listBoxRoles = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbEmployeeType = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbDisplayName = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.clientApplicationControl1 = new CRootLauncher.ClientApplicationControl();
            this.clientApplicationControl2 = new CRootLauncher.ClientApplicationControl();
            this.myScrollBar = new CRootLauncher.MyScrollBar(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BackColor = System.Drawing.Color.Gray;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer.Panel1.Controls.Add(this.listBoxRoles);
            this.splitContainer.Panel1.Controls.Add(this.label11);
            this.splitContainer.Panel1.Controls.Add(this.tbFirstName);
            this.splitContainer.Panel1.Controls.Add(this.label6);
            this.splitContainer.Panel1.Controls.Add(this.label7);
            this.splitContainer.Panel1.Controls.Add(this.label8);
            this.splitContainer.Panel1.Controls.Add(this.tbEmployeeType);
            this.splitContainer.Panel1.Controls.Add(this.label9);
            this.splitContainer.Panel1.Controls.Add(this.tbEmail);
            this.splitContainer.Panel1.Controls.Add(this.label10);
            this.splitContainer.Panel1.Controls.Add(this.tbDisplayName);
            this.splitContainer.Panel1.Controls.Add(this.tbLastName);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(4);
            this.splitContainer.Panel1MinSize = 150;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer.Panel2.Controls.Add(this.flowLayoutPanel);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.splitContainer.Panel2MinSize = 260;
            this.splitContainer.Size = new System.Drawing.Size(748, 440);
            this.splitContainer.SplitterDistance = 220;
            this.splitContainer.SplitterWidth = 3;
            this.splitContainer.TabIndex = 0;
            // 
            // listBoxRoles
            // 
            this.listBoxRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRoles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxRoles.FormattingEnabled = true;
            this.listBoxRoles.ItemHeight = 12;
            this.listBoxRoles.Location = new System.Drawing.Point(96, 141);
            this.listBoxRoles.Name = "listBoxRoles";
            this.listBoxRoles.Size = new System.Drawing.Size(117, 290);
            this.listBoxRoles.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(49, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "Roles:";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFirstName.Location = new System.Drawing.Point(96, 7);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.ReadOnly = true;
            this.tbFirstName.Size = new System.Drawing.Size(117, 21);
            this.tbFirstName.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "FirstName:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "LastName:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "DisplayName:";
            // 
            // tbEmployeeType
            // 
            this.tbEmployeeType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEmployeeType.Location = new System.Drawing.Point(96, 115);
            this.tbEmployeeType.Name = "tbEmployeeType";
            this.tbEmployeeType.ReadOnly = true;
            this.tbEmployeeType.Size = new System.Drawing.Size(117, 21);
            this.tbEmployeeType.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "Email:";
            // 
            // tbEmail
            // 
            this.tbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEmail.Location = new System.Drawing.Point(96, 88);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.ReadOnly = true;
            this.tbEmail.Size = new System.Drawing.Size(117, 21);
            this.tbEmail.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "EmployeeType:";
            // 
            // tbDisplayName
            // 
            this.tbDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDisplayName.Location = new System.Drawing.Point(96, 61);
            this.tbDisplayName.Name = "tbDisplayName";
            this.tbDisplayName.ReadOnly = true;
            this.tbDisplayName.Size = new System.Drawing.Size(117, 21);
            this.tbDisplayName.TabIndex = 18;
            // 
            // tbLastName
            // 
            this.tbLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLastName.Location = new System.Drawing.Point(96, 34);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.ReadOnly = true;
            this.tbLastName.Size = new System.Drawing.Size(117, 21);
            this.tbLastName.TabIndex = 19;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel.Controls.Add(this.clientApplicationControl1);
            this.flowLayoutPanel.Controls.Add(this.clientApplicationControl2);
            this.flowLayoutPanel.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel.Size = new System.Drawing.Size(514, 70);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // clientApplicationControl1
            // 
            this.clientApplicationControl1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.clientApplicationControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clientApplicationControl1.Location = new System.Drawing.Point(6, 6);
            this.clientApplicationControl1.Name = "clientApplicationControl1";
            this.clientApplicationControl1.Padding = new System.Windows.Forms.Padding(3);
            this.clientApplicationControl1.Size = new System.Drawing.Size(248, 58);
            this.clientApplicationControl1.TabIndex = 0;
            // 
            // clientApplicationControl2
            // 
            this.clientApplicationControl2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.clientApplicationControl2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clientApplicationControl2.Location = new System.Drawing.Point(260, 6);
            this.clientApplicationControl2.Name = "clientApplicationControl2";
            this.clientApplicationControl2.Padding = new System.Windows.Forms.Padding(3);
            this.clientApplicationControl2.Size = new System.Drawing.Size(248, 58);
            this.clientApplicationControl2.TabIndex = 1;
            // 
            // myScrollBar
            // 
            this.myScrollBar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.myScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.myScrollBar.Location = new System.Drawing.Point(748, 0);
            this.myScrollBar.Name = "myScrollBar";
            this.myScrollBar.Size = new System.Drawing.Size(17, 440);
            this.myScrollBar.TabIndex = 1;
            // 
            // AuthorizationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.myScrollBar);
            this.Name = "AuthorizationControl";
            this.Size = new System.Drawing.Size(765, 440);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox listBoxRoles;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbEmployeeType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbDisplayName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private ClientApplicationControl clientApplicationControl1;
        private ClientApplicationControl clientApplicationControl2;
        private MyScrollBar myScrollBar;
    }
}
