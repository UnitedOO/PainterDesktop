using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Painter.Models;
using System.Drawing.Drawing2D;
using Painter.Controllers;

namespace Painter.Views
{
    public partial class PFigure : UserControl
    {
        public enum FigureKeyPoint
        {
            none,
            topLeft, top, topRight, right,
            bottomRight, bottom, bottomLeft, left
        };

        private bool isMoving = false;
        private bool isResizing = false;
        private Point startPoint;
        private FigureKeyPoint figureKeyPoint;

        private Color _color;
        private int _lineWidth;
        private XData.FigureType _type;

        public Color Color { set { _color = value; Invalidate(); } }
        public int LineWidth { set { _lineWidth = value; Invalidate(); } }
        public XData.FigureType Type { set { _type = value; Invalidate(); } }

        public PFigure(int x, int y, int w, int h, XData xData, IXCommand xCommand)
        {
            //ContextMenuStrip = new CtxMenu(xCommand);

            Location = new Point(x, y);
            Size = new Size(w, h);
            _color = xData.color;
            _lineWidth = xData.lineWidth;
            _type = xData.type;

            Paint += PFigure_Paint;
            Click += PFigure_Click;
        }

        public MFigure GetMemento()
        {
            var figure = new MFigure();
            figure.x = Location.X;
            figure.y = Location.Y;
            figure.w = Width;
            figure.h = Height;

            figure.xData.color = _color;
            figure.xData.lineWidth = _lineWidth;
            figure.xData.type = _type;

            return figure;
        }

        public PFigure(PFigure pFigure)
        {
            //ContextMenuStrip = new CtxMenu(xCommand);

            Location = pFigure.Location;
            Size = pFigure.Size;
            _color = pFigure._color;
            _lineWidth = pFigure._lineWidth;
            _type = pFigure._type;

            Paint += PFigure_Paint;
            Click += PFigure_Click;
        }

        private void PFigure_Click(object sender, EventArgs e)
        {
            if ((Parent as PDraw).ActiveFigure == this)
                (Parent as PDraw).ActiveFigure = null;
            else
                (Parent as PDraw).ActiveFigure = this;
        }

        protected virtual void PFigure_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen pen = new Pen(_color, _lineWidth);
            if (_type == XData.FigureType.Rectangle)
                g.DrawRectangle(pen, new Rectangle(0, 0, Width - 1, Height - 1));
            else if (_type == XData.FigureType.Ellipse)
                g.DrawEllipse(pen, new Rectangle(0, 0, Width - 3, Height - 3));
            else if (_type == XData.FigureType.Line)
                g.DrawLine(pen, 0, 0, Width, Height);
            else if (_type == XData.FigureType.RoundRectangle)
            {
                GraphicsPath path = new GraphicsPath();
                Rectangle bounds = new Rectangle(0, 0, Width - 1, Height - 1);
                Size size = new Size(20, 20);
                Rectangle arc = new Rectangle(bounds.Location, size);
                path.AddArc(arc, 180, 90);
                arc.X = bounds.Right - 20;
                path.AddArc(arc, 270, 90);
                arc.Y = bounds.Bottom - 20;
                path.AddArc(arc, 0, 90);
                arc.X = bounds.Left;
                path.AddArc(arc, 90, 90);
                arc.Y = bounds.Top;
                path.CloseFigure();
                g.DrawPath(pen, path);
            }
        }
    }
}
