using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRootLauncher
{
    public class CloseButton : Button
    {
        public CloseButton()
        {
            this.Paint += CloseButton_Paint;

            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = SystemColors.ButtonHighlight;
            this.FlatAppearance.BorderSize = 0;
            //this.FlatAppearance.BorderColor = SystemColors.ButtonShadow;
            this.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            this.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            this.Size = new Size(25, 25);

            solidBrush = new SolidBrush(this.ForeColor);
            pen = new Pen(solidBrush, 2);
            //lt = new PointF(this.Width / split * 1, this.Height / split * 1);
            //rt = new PointF(this.Width / split * 4, this.Height / split * 1);
            //lb = new PointF(this.Width / split * 1, this.Height / split * 4);
            //rb = new PointF(this.Width / split * 4, this.Height / split * 4);
            lt = new PointF(bound, bound);
            rt = new PointF(this.Width - bound, bound);
            lb = new PointF(bound, this.Height - bound);
            rb = new PointF(this.Width- bound, this.Height - bound);
        }

        int bound = 6;
        SolidBrush solidBrush;
        Pen pen;
        PointF lt;
        PointF rt;
        PointF lb;
        PointF rb;

        public override string Text { get => ""; }

        private void CloseButton_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawLine(pen, lt, rb);
            g.DrawLine(pen, lb, rt);
        }
    }
}
