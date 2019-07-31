using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRootLauncher
{
    public partial class MyScrollBar : Panel
    {
        public MyScrollBar()
        {
            InitializeComponent();

            Init();
        }

        public MyScrollBar(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            Init();
        }

        Graphics graphics;
        SolidBrush normalBrush = new SolidBrush(SystemColors.ControlLight);
        SolidBrush mouseOverBrush = new SolidBrush(SystemColors.Info);
        SolidBrush mouseDownBrush = new SolidBrush(SystemColors.HotTrack);
        SolidBrush backgroundBrush = new SolidBrush(SystemColors.ButtonFace);
        SolidBrush arrowBrush1 = new SolidBrush(SystemColors.ControlLight);
        SolidBrush arrowBrush2 = new SolidBrush(SystemColors.ControlLight);
        SolidBrush slideBrush = new SolidBrush(SystemColors.ControlLight);

        DirectionType direction = DirectionType.Veritcal;
        Control targetControl = null;
        Control parentControl = null;
        int arrowLength = 17;   //箭头长度

        [DefaultValue(DirectionType.Veritcal)]
        public DirectionType Direction
        {
            get => direction;
            set
            {
                if (direction != value)
                {
                    direction = value;
                    OnDirectionChanged();
                }
            }
        }

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public Control TargetControl { get => targetControl; set => targetControl = value; }

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public Control ParentControl { get => parentControl; set => parentControl = value; }

        private Graphics CurrentGraphics
        {
            get
            {
                if (graphics == null)
                    this.graphics = CreateGraphics();
                return graphics;
            }
        }

        private int ParentWidth { get => parentControl.Width - parentControl.Padding.Horizontal; }

        private int ParentHeight { get => parentControl.Height - parentControl.Padding.Vertical; }

        private float SlideLength
        {
            get
            {
                if (targetControl != null && parentControl != null)
                {
                    int length = 0;
                    switch (direction)
                    {
                        case DirectionType.Veritcal:
                            if (targetControl.Height > 0)
                                length = (this.Height - arrowLength * 2) * ParentHeight / targetControl.Height;
                            break;
                        case DirectionType.Horizontal:
                            if (targetControl.Width > 0)
                                length = (this.Width - arrowLength * 2) * ParentWidth / targetControl.Width;
                            break;
                    }
                    return length;
                }
                return 0;
            }
        }

        /// <summary>
        /// 滑块位置（坐标的x或y）
        /// </summary>
        private float SlideLocation
        {
            get
            {
                if (targetControl != null && parentControl != null)
                {
                    int location = 0;
                    switch (direction)
                    {
                        case DirectionType.Veritcal:
                            if (targetControl.Height > 0)
                                location = (int)((this.Height - arrowLength * 2) * (1 - (float)ParentHeight / targetControl.Height) * (-targetControl.Top) / (targetControl.Height - ParentHeight) + arrowLength);
                            break;
                        case DirectionType.Horizontal:
                            if (targetControl.Width > 0)
                                location = (int)((this.Width - arrowLength * 2) * (1 - (float)ParentWidth / targetControl.Width) * (-targetControl.Left) / (targetControl.Width - ParentWidth) + arrowLength);
                            break;
                    }
                    return location;
                }
                return arrowLength;
            }
            set
            {
                if (targetControl != null && parentControl != null)
                {
                    int location = (int)value;
                    switch (direction)
                    {
                        case DirectionType.Veritcal:
                            targetControl.Top = (int)(-(targetControl.Height - ParentHeight) * (location - arrowLength) / ((this.Height - arrowLength * 2) * (1 - (float)ParentHeight / targetControl.Height)));
                            break;
                        case DirectionType.Horizontal:
                            targetControl.Left = (int)(-(targetControl.Width - ParentWidth) * (location - arrowLength) / ((this.Width - arrowLength * 2) * (1 - (float)ParentWidth / targetControl.Width)));
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 滑块区域（距离边界2像素）
        /// </summary>
        private RectangleF SlideRectangle
        {
            get
            {
                RectangleF rect = direction == DirectionType.Veritcal
                    ? new RectangleF(2, SlideLocation, arrowLength - 4, SlideLength)
                    : new RectangleF(SlideLocation, 2, SlideLength, arrowLength - 4);
                return rect;
            }
        }

        private RectangleF BackgroundRectangle1
        {
            get
            {
                RectangleF rect = this.SlideRectangle;
                switch (direction)
                {
                    case DirectionType.Veritcal:
                        {
                            RectangleF backRect = new RectangleF(0, arrowLength, this.Width, rect.Top - arrowLength);
                            return backRect;
                        }
                    case DirectionType.Horizontal:
                        {
                            RectangleF backRect = new RectangleF(arrowLength, 0, rect.Left - arrowLength, this.Height);
                            return backRect;
                        }
                    default:
                        return new RectangleF();
                }
            }
        }

        private RectangleF BackgroundRectangle2
        {
            get
            {
                RectangleF rect = this.SlideRectangle;
                switch (direction)
                {
                    case DirectionType.Veritcal:
                        {
                            RectangleF backRect = new RectangleF(0, rect.Bottom, this.Width, this.Height - rect.Bottom - arrowLength);
                            return backRect;
                        }
                    case DirectionType.Horizontal:
                        {
                            RectangleF backRect = new RectangleF(rect.Right, 0, this.Width - rect.Right - arrowLength, this.Height);
                            return backRect;
                        }
                    default:
                        return new RectangleF();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Draw(e.Graphics);
        }

        public void InitTargetControl(Control target, Control parent)
        {
            if (target != null && parent != null)
            {
                if (this.targetControl != null)
                {
                    this.targetControl.LocationChanged -= TargetControl_LocationChanged;
                    this.targetControl.SizeChanged -= TargetControl_SizeChanged;
                }
                if (this.parentControl != null)
                    this.parentControl.SizeChanged -= ParentControl_SizeChanged;
                this.targetControl = target;
                this.parentControl = parent;
                this.targetControl.LocationChanged += TargetControl_LocationChanged;
                this.targetControl.SizeChanged += TargetControl_SizeChanged;
                this.parentControl.SizeChanged += ParentControl_SizeChanged;
            }
        }

        private void TargetControl_LocationChanged(object sender, EventArgs e)
        {
            Draw(CurrentGraphics);
        }

        private void TargetControl_SizeChanged(object sender, EventArgs e)
        {
            this.Visible = direction == DirectionType.Veritcal
                ? this.targetControl.Height > ParentHeight
                : this.targetControl.Width > ParentWidth;
        }

        private void ParentControl_SizeChanged(object sender, EventArgs e)
        {
            this.Visible = direction == DirectionType.Veritcal
                ? this.targetControl.Height > ParentHeight
                : this.targetControl.Width > ParentWidth;
        }

        void OnDirectionChanged()
        {
            this.SuspendLayout();
            switch (direction)
            {
                case DirectionType.Veritcal:
                    this.Width = arrowLength;
                    this.Dock = DockStyle.Right;
                    break;
                case DirectionType.Horizontal:
                    this.Height = arrowLength;
                    this.Dock = DockStyle.Bottom;
                    break;
            }
            this.ResumeLayout();
        }

        void Init()
        {
            this.MouseDown += MyScrollBar_MouseDown;
            this.MouseUp += MyScrollBar_MouseUp;
            this.MouseMove += MyScrollBar_MouseMove;
            this.MouseLeave += MyScrollBar_MouseLeave;

            OnDirectionChanged();
        }

        bool mouseDown;
        Point mouseDownPoint;
        Point mouseDownToSlidePoint;
        Point mouseMovePoint;

        private void MyScrollBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint = e.Location;
                mouseDownToSlidePoint = new Point(mouseDownPoint.X - (int)SlideRectangle.Location.X, mouseDownPoint.Y - (int)SlideRectangle.Location.Y);

                if (MouseOnArrows(e.Location, e.Button))
                {
                    if (!mouseDown)
                        Draw(CurrentGraphics);
                    if (IsMouseOnArrow(true, e.Location))
                    {
                        float location = SlideLocation - 20;
                        if (location < arrowLength)
                            location = arrowLength;
                        SlideLocation = location;
                    }
                    else if (IsMouseOnArrow(false, e.Location))
                    {
                        int total = direction == DirectionType.Veritcal ? this.Height : this.Width;
                        float max = total - SlideLength - arrowLength;
                        float location = SlideLocation + 20;
                        if (location > max)
                            location = max;
                        SlideLocation = location;
                    }
                    return;
                }
                if (MouseOnSlide(e.Location, e.Button))
                {
                    if (!mouseDown)
                        Draw(CurrentGraphics);
                    return;
                }
                //TODO:点击背景
                IsOnBackgroundClicked(e.Location, e.Button);
                mouseDown = true;
            }
        }

        private void MyScrollBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = false;
                if (MouseOnArrows(e.Location, MouseButtons.None))
                {
                    Draw(CurrentGraphics);
                    return;
                }

                if (MouseOnSlide(e.Location, MouseButtons.None))
                {
                    Draw(CurrentGraphics);
                    return;
                }
            }
        }

        private void MyScrollBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMovePoint == e.Location)
                return;
            mouseMovePoint = e.Location;
            Point mousePoint = e.Location;
            if (MouseOnArrows(mousePoint, e.Button))
            {
                Draw(CurrentGraphics);
                return;
            }

            if (MouseOnSlide(mousePoint, e.Button))
            {
                if (e.Button == MouseButtons.Left && IsMouseDownInSlide())
                {
                    int location = arrowLength;
                    int total = direction == DirectionType.Veritcal ? this.Height : this.Width;
                    float max = total - SlideLength - arrowLength;
                    switch (direction)
                    {
                        case DirectionType.Veritcal:
                            location = mousePoint.Y - mouseDownToSlidePoint.Y;
                            if (location < arrowLength)
                                location = arrowLength;
                            else if (location > max)
                                location = (int)max;
                            SlideLocation = location;
                            break;
                        case DirectionType.Horizontal:
                            location = mousePoint.X - mouseDownToSlidePoint.X;
                            if (location < arrowLength)
                                location = arrowLength;
                            else if (location > max)
                                location = (int)max;
                            SlideLocation = location;
                            break;
                    }
                }
                Draw(CurrentGraphics);
                return;
            }

            //背景区域
            arrowBrush1 = normalBrush;
            arrowBrush2 = normalBrush;
            slideBrush = normalBrush;
            Draw(CurrentGraphics);
        }

        private void MyScrollBar_MouseLeave(object sender, EventArgs e)
        {
            arrowBrush1 = normalBrush;
            arrowBrush2 = normalBrush;
            slideBrush = normalBrush;
            Draw(CurrentGraphics);
        }

        bool MouseOnArrows(Point mousePoint, MouseButtons button)
        {
            if (IsMouseOnArrow(true, mousePoint))
            {
                //上/左箭头区域
                arrowBrush1 = button == MouseButtons.Left ? mouseDownBrush : mouseOverBrush;
                arrowBrush2 = normalBrush;
                slideBrush = normalBrush;
                return true;
            }
            else if (IsMouseOnArrow(false, mousePoint))
            {
                //下/右箭头区域
                arrowBrush1 = normalBrush;
                arrowBrush2 = button == MouseButtons.Left ? mouseDownBrush : mouseOverBrush;
                slideBrush = normalBrush;
                return true;
            }
            return false;
        }

        bool IsMouseOnArrow(bool isTopOrLeft, Point mousePoint)
        {
            Rectangle rect = isTopOrLeft
                ? new Rectangle(0, 0, arrowLength, arrowLength)
                : new Rectangle(this.Width - arrowLength, this.Height - arrowLength, arrowLength, arrowLength);
            return rect.Contains(mousePoint);
        }

        bool MouseOnSlide(Point mousePoint, MouseButtons button)
        {
            RectangleF rect = SlideRectangle;
            if (IsMouseOnSlide(rect, mousePoint, button))
            {
                //滑块区域
                arrowBrush1 = normalBrush;
                arrowBrush2 = normalBrush;
                slideBrush = button == MouseButtons.Left ? IsMouseDownInSlide() ? mouseDownBrush : normalBrush : mouseOverBrush;
                return true;
            }
            return false;
        }

        bool IsMouseOnSlide(RectangleF rect, Point mousePoint, MouseButtons button)
        {
            if (button == MouseButtons.Left)
                return direction == DirectionType.Veritcal
                    ? rect.Top <= mousePoint.Y && rect.Bottom >= mousePoint.Y
                    : rect.Left <= mousePoint.X && rect.Right >= mousePoint.X;
            else
                return rect.Contains(mousePoint);
        }

        bool IsOnBackgroundClicked(Point mousePoint, MouseButtons button)
        {
            if (button == MouseButtons.Left && BackgroundRectangle1.Contains(mousePoint))
            {
                float location = SlideLocation - SlideLength;
                if (location < arrowLength)
                    location = arrowLength;
                SlideLocation = location;
                return true;
            }
            else if (button == MouseButtons.Left && BackgroundRectangle2.Contains(mousePoint))
            {
                int total = direction == DirectionType.Veritcal ? this.Height : this.Width;
                float location = SlideLocation + SlideLength;
                float max = total - SlideLength - arrowLength;
                if (location > max)
                    location = max;
                SlideLocation = location;
                return true;
            }
            return false;
        }

        bool IsMouseDownInSlide()
        {
            float pos = direction == DirectionType.Veritcal ? mouseDownToSlidePoint.Y : mouseDownToSlidePoint.X;
            return pos > 0 && pos < SlideLength;
        }

        void Draw(Graphics g)
        {
            DrawArrows(g);
            DrawSlide(g);
            DrawBackground(g);
        }

        void DrawArrows(Graphics g)
        {
            PointF[] points1 = null;
            PointF[] points2 = null;
            switch (direction)
            {
                case DirectionType.Veritcal:
                    {
                        points1 = new PointF[]
                        {
                            new PointF(this.Width/2f, 3f),
                            new PointF(3f, this.Top+14f),
                            new PointF(this.Width-3f, 14f),
                            new PointF(this.Width/2f, 3f),
                        };
                        points2 = new PointF[]
                        {
                            new PointF(this.Width/2f, this.Height-3f),
                            new PointF(3f, this.Height-14f),
                            new PointF(this.Width-3f, this.Height-14f),
                            new PointF(this.Width/2f, this.Height-3f),
                        };
                    }
                    break;
                case DirectionType.Horizontal:
                    {
                        points1 = new PointF[]
                        {
                            new PointF(this.Height/2f, 3f),
                            new PointF(this.Height-3f, 14f),
                            new PointF(3f, this.Left+14f),
                            new PointF(this.Height/2f, 3f),
                        };
                        points2 = new PointF[]
                        {
                            new PointF(this.Height/2f, this.Width-3f),
                            new PointF(this.Height-3f, this.Width-14f),
                            new PointF(3f, this.Width-14f),
                            new PointF(this.Height/2f, this.Width-3f),
                        };
                    }
                    break;
            }
            if (points1 != null && points2 != null)
            {
                g.FillPolygon(arrowBrush1, points1);
                g.FillPolygon(arrowBrush2, points2);
            }
        }

        void DrawSlide(Graphics g)
        {
            //var form = this.FindForm();
            //if (form != null)
            //    form.Text = rect.ToString();
            RectangleF rect = this.SlideRectangle;
            g.FillRectangle(slideBrush, rect);
        }

        void DrawBackground(Graphics g)
        {
            //switch (direction)
            //{
            //    case DirectionType.Veritcal:
            //        {
            //            RectangleF backRect1 = new RectangleF(0, arrowLength, this.Width, rect.Top - arrowLength);
            //            RectangleF backRect2 = new RectangleF(0, rect.Bottom, this.Width, this.Height - rect.Bottom - arrowLength);
            //            g.FillRectangles(backgroundBrush, new RectangleF[] { backRect1, backRect2 });
            //        }
            //        break;
            //    case DirectionType.Horizontal:
            //        {
            //            RectangleF backRect1 = new RectangleF(arrowLength, 0, rect.Left - arrowLength, this.Height);
            //            RectangleF backRect2 = new RectangleF(rect.Right, 0, this.Width - rect.Right - arrowLength, this.Height);
            //            g.FillRectangles(backgroundBrush, new RectangleF[] { backRect1, backRect2 });
            //        }
            //        break;
            //}
            g.FillRectangles(backgroundBrush, new RectangleF[] { BackgroundRectangle1, BackgroundRectangle2 });
        }
    }

    public enum DirectionType
    {
        Veritcal,
        Horizontal
    }
}
