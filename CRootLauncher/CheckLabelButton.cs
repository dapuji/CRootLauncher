using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRootLauncher
{
    public class CheckLabelButton : Label
    {
        public event EventHandler Active;

        [DefaultValue(false)]
        public bool Checked { get; set; }
        public Color MouseOverBackColor { get; set; } = SystemColors.Info;
        public Color ActiveBackColor { get; set; } = SystemColors.HotTrack;
        public Color ActiveForeColor { get; set; } = SystemColors.HighlightText;
        public Color InactiveBackColor { get; set; } = SystemColors.ControlLight;
        public Color InactiveForeColor { get; set; } = SystemColors.ControlText;

        public CheckLabelButton()
        {
            this.MouseEnter += CheckLabelButton_MouseEnter;
            this.MouseLeave += CheckLabelButton_MouseLeave;
            this.MouseDown += CheckLabelButton_MouseDown;

            this.BorderStyle = BorderStyle.None;
            this.BackColor = InactiveBackColor;
            this.ForeColor = InactiveForeColor;

            this.Size = new Size(100, 23);
            this.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void CheckLabelButton_MouseEnter(object sender, EventArgs e)
        {
            if (!Checked)
                this.BackColor = MouseOverBackColor;
        }

        private void CheckLabelButton_MouseLeave(object sender, EventArgs e)
        {
            if (!Checked)
                this.BackColor = InactiveBackColor;
        }
        
        private void CheckLabelButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Activate();
            }
        }

        public override bool AutoSize { get => false; }

        public override Cursor Cursor { get => Cursors.Hand; }

        public void Activate()
        {
            if (!Checked)
            {
                Checked = true;
                this.BorderStyle = BorderStyle.FixedSingle;
                this.BackColor = ActiveBackColor;
                this.ForeColor = ActiveForeColor;
                this.Active?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Deactivate()
        {
            if (Checked)
            {
                Checked = false;
                this.BorderStyle = BorderStyle.None;
                this.BackColor = InactiveBackColor;
                this.ForeColor = InactiveForeColor;
            }
        }
    }
}
