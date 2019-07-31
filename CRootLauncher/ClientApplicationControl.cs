using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CRootLauncher
{
    public partial class ClientApplicationControl : UserControl
    {
        public event EventHandler ControlClick;

        private Color normalBackColor = SystemColors.GradientInactiveCaption;
        private Color mouseOverBackColor = SystemColors.GradientActiveCaption;
        private Color mouseDownBackColor = SystemColors.ButtonHighlight;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FilePath { get; set; }

        public ClientApplicationControl()
        {
            InitializeComponent();

            this.Click += ClientApplicationControl_Click;
            this.MouseEnter += ClientApplicationControl_MouseEnter;
            this.MouseLeave += ClientApplicationControl_MouseLeave;
            this.MouseUp += ClientApplicationControl_MouseUp;
            this.MouseDown += ClientApplicationControl_MouseDown;

            //pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            FilePath = Application.ExecutablePath;
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            this.lbFileName.Text = info.OriginalFilename;
            this.lbDescription.Text = info.FileDescription;
            this.lbVersion.Text = info.FileVersion;
            SetImage(Application.ExecutablePath);
        }

        private void ClientApplicationControl_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = e as MouseEventArgs;
            if (args != null && args.Button == MouseButtons.Left)
                ControlClick?.Invoke(this, e);
        }

        private ClientApplicationControl(string filePath) : this()
        {
            //if (File.Exists(filePath))
            {
                FilePath = filePath;
                FileVersionInfo info = FileVersionInfo.GetVersionInfo(filePath);
                this.lbFileName.Text = info.OriginalFilename;
                this.lbDescription.Text = info.FileDescription;
                this.lbVersion.Text = info.FileVersion;
                SetImage(filePath);
            }
        }

        public static ClientApplicationControl CreateControl(string filePath)
        {
            if (File.Exists(filePath))
                return new ClientApplicationControl(filePath);
            return null;
        }

        private void ClientApplicationControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = mouseOverBackColor;
        }

        private void ClientApplicationControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = normalBackColor;
        }

        private void ClientApplicationControl_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackColor = mouseOverBackColor;
        }

        private void ClientApplicationControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor = mouseDownBackColor;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            Control control = e.Control;
            control.Click += SubControl_Click;
            control.MouseLeave += SubControl_MouseLeave;
            control.MouseUp += SubControl_MouseUp;
            control.MouseDown += SubControl_MouseDown;
            base.OnControlAdded(e);
        }

        private void SubControl_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void SubControl_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        private void SubControl_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if(!this.ClientRectangle.Contains(PointToClient(Control.MousePosition)))
                base.OnMouseLeave(e);
        }

        private void SubControl_MouseLeave(object sender, EventArgs e)
        {
            if (!this.ClientRectangle.Contains(PointToClient(Control.MousePosition)))
                base.OnMouseLeave(e);
        }

        void SetImage(string filePath)
        {
            Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(filePath);
            Image image = icon.ToBitmap();
            pictureBox.Image = image;
        }
    }
}
