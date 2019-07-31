using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace CRootLauncher
{
    public partial class AuthorizationControl : UserControl
    {
        List<ClientApplicationControl> clientApplicationControls = new List<ClientApplicationControl>();

        public AuthorizationControl()
        {
            InitializeComponent();

            this.splitContainer.Panel1.MouseDown += Container_MouseDown;
            this.splitContainer.Panel2.MouseDown += Container_MouseDown;
            this.flowLayoutPanel.MouseDown += Container_MouseDown;
            this.flowLayoutPanel.MouseEnter += FlowLayoutPanel_MouseEnter;
            this.flowLayoutPanel.MouseWheel += FlowLayoutPanel_MouseWheel;
            this.splitContainer.Panel2.Resize += Panel2_Resize;
            this.splitContainer.Panel2.VerticalScroll.Visible = false;

            this.clientApplicationControl1.ControlClick += ClientControl_ControlClick;
            this.clientApplicationControl2.ControlClick += ClientControl_ControlClick;

            InitClientApplicationPanel();
            this.myScrollBar.InitTargetControl(this.flowLayoutPanel, this.splitContainer.Panel2);
            flpWidth = this.flowLayoutPanel.Width;

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.Selectable |
                ControlStyles.DoubleBuffer |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.Opaque, false);
            //base.BackColor = Color.Transparent;

            this.UpdateStyles();
        }

        int scrollLength = 0;
        int flpWidth = 0;
        private void Panel2_Resize(object sender, EventArgs e)
        {
            int sw = this.splitContainer.Panel2.Width - this.splitContainer.Panel2.Padding.Horizontal;
            if (sw < this.flowLayoutPanel.Width
                || sw > this.flowLayoutPanel.Width + this.clientApplicationControl1.Width + this.clientApplicationControl1.Margin.Horizontal)
            {
                this.flowLayoutPanel.MaximumSize = new Size(sw, 0);
                if (Math.Abs(flpWidth - this.flowLayoutPanel.Width) > 1)
                {
                    this.flowLayoutPanel.Top = 0;
                    flpWidth = this.flowLayoutPanel.Width;
                }
            }
            int fh = this.flowLayoutPanel.PreferredSize.Height;
            int sh = this.splitContainer.Panel2.Height - this.splitContainer.Panel2.Padding.Vertical;
            if (fh > sh)
                scrollLength = sh - fh;
            else
                scrollLength = 0;
        }

        private void FlowLayoutPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            //VScrollProperties vScroll = this.flowLayoutPanel.VerticalScroll;
            //Point current = this.flowLayoutPanel.AutoScrollPosition;
            int y = this.flowLayoutPanel.Top;
            int delta = e.Delta;
            if (delta < 0)
                y = Math.Max(y - 10, scrollLength);
            else
                y = Math.Min(y + 10, 0);
            this.flowLayoutPanel.Top = y;
            //if (delta < 0)
            //    this.flowLayoutPanel.AutoScrollPosition = new Point(current.X, current.Y - vScroll.LargeChange);
            //else
            //    this.flowLayoutPanel.AutoScrollPosition = new Point(current.X, current.Y + vScroll.LargeChange);
        }

        private void FlowLayoutPanel_MouseEnter(object sender, EventArgs e)
        {
            Panel container = sender as Panel;
            if (container != null)
                container.Focus();
        }

        List<string> GetLocalExeFilePaths()
        {
            List<string> paths = new List<string>();
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            string cts = Path.Combine("cts");
            string etf = Path.Combine("etf");
            string futures = Path.Combine("futures");
            //AppendFiles(dir, paths);
            AppendFiles(cts, paths);
            AppendFiles(etf, paths);
            AppendFiles(futures, paths);

            return paths;
        }

        void AppendFiles(string dir, List<string> files)
        {
            if (Directory.Exists(dir))
                files.AddRange(Directory.GetFiles(dir, "*.exe"));
        }

        void InitClientApplicationList(List<string> fileList)
        {
            clientApplicationControls.ForEach(c => c.ControlClick -= ClientControl_ControlClick);
            clientApplicationControls.Clear();
            fileList.ForEach(filePath =>
            {
                ClientApplicationControl control = ClientApplicationControl.CreateControl(filePath);
                if (control != null)
                {
                    control.ControlClick += ClientControl_ControlClick;
                    clientApplicationControls.Add(control);
                }
            });
        }

        void InitClientApplicationPanel()
        {
            try
            {
                List<string> fileList = GetLocalExeFilePaths();
                if (fileList.Any())
                {
                    InitClientApplicationList(fileList);
                    this.flowLayoutPanel.Controls.Clear();
                    clientApplicationControls.ForEach(control =>
                    {
                        this.flowLayoutPanel.Controls.Add(control);
                    });
                }
            }
            catch (Exception ex)
            {
                //TODO
            }
        }

        private void ClientControl_ControlClick(object sender, EventArgs e)
        {
            MessageBox.Show(((ClientApplicationControl)sender).FilePath);
        }

        #region API
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void Container_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.ParentForm.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        #endregion
    }
}
