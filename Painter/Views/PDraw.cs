using Painter.Controllers;
using Painter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter.Views
{
    public partial class PDraw : TabPage
    {
        private IXCommand _xCommand = null;
        private PFigure _activeFigure;

        public XData _xData = new XData();
        public PFigure ActiveFigure
        {
            get => _activeFigure;
            set
            {
                _activeFigure = value;
                _xCommand.ActiveFigure = _activeFigure;
            }
        }

        public PDraw(IXCommand xCommand)
        {
            BackColor = Color.White;
            _xCommand = xCommand;
            Click += PDraw_Click;
        }

        private void PDraw_Click(object sender, EventArgs e)
        {
            var mouse = e as MouseEventArgs;
            PFigure figure = new PFigure(mouse.X, mouse.Y, 70, 70, _xData, _xCommand);
            Controls.Add(_xCommand.PluginProcess(figure));
        }

        public MTab GetMemento()
        {
            List<MFigure> figures = new List<MFigure>();
            foreach (var figure in Controls)
            {
                figures.Add((figure as PFigure).GetMemento());
            }

            MTab mTab = new MTab();
            mTab.mFigures = figures;
            mTab.Name = Text;

            return mTab;
        }

        public void SetMemento(MTab mTab)
        {
            foreach (var figure in mTab.mFigures)
            {
                PFigure pFigure = new PFigure(
                    figure.x,
                    figure.y,
                    figure.w,
                    figure.h,
                    figure.xData,
                    _xCommand
                );
                Controls.Add(pFigure);
            }
            Text = mTab.Name;
        }
    }
}
