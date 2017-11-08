using Painter.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter.Views
{
    public partial class PStatusBar : StatusStrip
    {
        private IXCommand _xCommand;
        public PStatusBar(IXCommand xCommand)
        {
            _xCommand = xCommand;
            ToolStripStatusLabel statusLbl = new ToolStripStatusLabel("X:  Y: ");
            Items.Add(statusLbl);
        }
    }
}
