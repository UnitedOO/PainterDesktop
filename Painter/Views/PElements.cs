using Painter.Controllers;
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
    public partial class PElements : Panel
    {
        private IXCommand _xCommand;

        private GroupBox _figureTypeGroupBox;
        private Button _simpleFigure;

        public PElements(IXCommand xCommand)
        {
            _xCommand = xCommand;

            _figureTypeGroupBox = new GroupBox();
            _figureTypeGroupBox.Parent = this;
            _figureTypeGroupBox.Text = Localization.GetText("figure_type_text_id");
            _figureTypeGroupBox.Location = new Point(0, 0);
            _figureTypeGroupBox.Size = new Size(Width - 10, 200);

            _simpleFigure = new Button();
            _simpleFigure.Parent = _figureTypeGroupBox;
            _simpleFigure.Text = Localization.GetText("simple_figure_text_id");
            _simpleFigure.Location = new Point(10, 20);
            _simpleFigure.Size = new Size(100, 35);
            _simpleFigure.Click += delegate { _xCommand.ActiveFigurePlugin = null; };

            //int y = 30;
            //Button r = new Button();
            //r.Text = "Simple Figure";
            //r.Location = new Point(10, y);
            //r.Width = 130;
            //y += 30;
            //r.Click += delegate
            //{
            //    _xCommand.ActiveFigurePlugin = null;
            //};
            // Controls.Add(r);
            int y = 30;
            foreach (var plugin in xCommand.FigurePlugins)
            {
                Button b = plugin.GetElements();
                b.Location = new Point(10, y);
                b.Width = 130;
                b.Click += delegate
                {
                    _xCommand.ActiveFigurePlugin = plugin;
                };
                y += 30;
                Controls.Add(b);
            }

            SkinController.OnSkinChange += SkinController_OnSkinChange;
        }

        private void SkinController_OnSkinChange()
        {
           // BackColor = SkinController.GetColor("primaryColor");
           // ForeColor = SkinController.GetColor("primaryTextColor");
        }
    }
}
