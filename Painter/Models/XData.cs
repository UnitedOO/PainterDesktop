using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Models
{
    public class XData
    {
        public enum FigureType { Rectangle, Ellipse, RoundRectangle, Line };

        public Color color = Color.Red;
        public int lineWidth = 1;
        public FigureType type = FigureType.Rectangle;
    }
}
