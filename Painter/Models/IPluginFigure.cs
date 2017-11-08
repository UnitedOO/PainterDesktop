using Painter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter.Models
{
    public interface IPluginFigure : IPlugin
    {
        ToolStrip GetToolStrip();
        ToolStripMenuItem GetMenuStrip();
        GroupBox GetToolBox();
        Button GetElements();

        PFigure ActiveFigure { set; }
        PFigure Process(PFigure figure);
    }
}
