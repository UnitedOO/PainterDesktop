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
    public partial class PToolBox : Panel
    {
        private IXCommand _xCommand;

        private GroupBox _emptyFigureGroupBox;
        private GroupBox _filesGroupBox;
        private Button _line;
        private Button _rect;
        private Button _ellipse;
        private Button _roundRect;
        private Button _color;
        private Label _lineWidthLabel;
        private Label _colorLbl;
        private Label _typeLbl;
        private ComboBox _lineWidth;
        private Button _save;
        private Button _open;

        public PToolBox(IXCommand xCommand)
        {
            _xCommand = xCommand;

            // properties
            _emptyFigureGroupBox = new GroupBox();
            _emptyFigureGroupBox.Parent = this;
            _emptyFigureGroupBox.Text = Localization.GetText("properties_text_id");
            _emptyFigureGroupBox.Location = new System.Drawing.Point(0, 0);
            _emptyFigureGroupBox.Size = new System.Drawing.Size(Width - 5, 490);

            _typeLbl = new Label();
            _typeLbl.Parent = _emptyFigureGroupBox;
            _typeLbl.Text = Localization.GetText("types_text_id");
            _typeLbl.Location = new System.Drawing.Point(10, 20);
            _typeLbl.Size = new System.Drawing.Size(40, 25);

            _line = new Button();
            _line.Parent = _emptyFigureGroupBox;
            _line.Text = Localization.GetText("line_text_id");
            _line.Location = new System.Drawing.Point(50, 20);
            _line.Size = new System.Drawing.Size(100, 25);
            _line.Click += delegate { _xCommand.SetType(Models.XData.FigureType.Line); };

            _rect = new Button();
            _rect.Parent = _emptyFigureGroupBox;
            _rect.Text = Localization.GetText("rectangle_text_id");
            _rect.Location = new System.Drawing.Point(50, 46);
            _rect.Size = new System.Drawing.Size(100, 25);
            _rect.Click += delegate { _xCommand.SetType(Models.XData.FigureType.Rectangle); };

            _roundRect = new Button();
            _roundRect.Parent = _emptyFigureGroupBox;
            _roundRect.Text = Localization.GetText("rounded_rectangle_text_id");
            _roundRect.Location = new System.Drawing.Point(50, 72);
            _roundRect.Size = new System.Drawing.Size(100, 25);
            _roundRect.Click += delegate { _xCommand.SetType(Models.XData.FigureType.RoundRectangle); };

            _ellipse = new Button();
            _ellipse.Parent = _emptyFigureGroupBox;
            _ellipse.Text = Localization.GetText("ellipse_text_id");
            _ellipse.Location = new System.Drawing.Point(50, 98);
            _ellipse.Size = new System.Drawing.Size(100, 25);
            _ellipse.Click += delegate { _xCommand.SetType(Models.XData.FigureType.Ellipse); };

            _colorLbl = new Label();
            _colorLbl.Parent = _emptyFigureGroupBox;
            _colorLbl.Text = Localization.GetText("color_text_id");
            _colorLbl.Location = new System.Drawing.Point(10, 133);
            _colorLbl.Size = new System.Drawing.Size(40, 25);

            _color = new Button();
            _color.Parent = _emptyFigureGroupBox;
            _color.Text = Localization.GetText("color_text_id");
            _color.Location = new System.Drawing.Point(50, 133);
            _color.Size = new System.Drawing.Size(100, 25);
            _color.Click += delegate
            {
                try
                {
                    _xCommand.SetColor(Utilities.GetColor());
                }
                catch { }
            };

            _lineWidthLabel = new Label();
            _lineWidthLabel.Parent = _emptyFigureGroupBox;
            _lineWidthLabel.Text = Localization.GetText("width_text_id");
            _lineWidthLabel.Location = new System.Drawing.Point(10, 168);
            _lineWidthLabel.Size = new System.Drawing.Size(40, 25);


            _lineWidth = new ComboBox();
            _lineWidth.Parent = _emptyFigureGroupBox;
            _lineWidth.Items.Add(1);
            _lineWidth.Items.Add(5);
            _lineWidth.Items.Add(10);
            _lineWidth.Items.Add(15);
            _lineWidth.Items.Add(20);
            _lineWidth.SelectedIndex = 0;
            _lineWidth.Text = Localization.GetText("color_text_id");
            _lineWidth.Location = new System.Drawing.Point(50, 168);
            _lineWidth.Size = new System.Drawing.Size(100, 25);
            _lineWidth.Click += delegate { try { _xCommand.SetLineWidth(Int32.Parse(_lineWidth.SelectedText)); } catch { } };

            // files
            _filesGroupBox = new GroupBox();
            _filesGroupBox.Parent = this;
            _filesGroupBox.Text = Localization.GetText("file_text_id");
            _filesGroupBox.Location = new System.Drawing.Point(0, 492);
            _filesGroupBox.Size = new System.Drawing.Size(Width - 5, 70);

            _save = new Button();
            _save.Parent = _filesGroupBox;
            _save.Text = Localization.GetText("save_text_id");
            _save.Location = new System.Drawing.Point(10, 20);
            _save.Size = new System.Drawing.Size(140, 25);
            _save.Click += delegate { _xCommand.SaveInCloud(); };

            _open = new Button();
            _open.Parent = _filesGroupBox;
            _open.Text = Localization.GetText("open_text_id");
            _open.Location = new System.Drawing.Point(10, 46);
            _open.Size = new System.Drawing.Size(140, 25);
            _open.Click += delegate { _xCommand.OpenFromCloud(); };

            Localization.OnLocalChange += Localization_OnLocalChange;
            _xCommand.OnFigurePluginChanged += _xCommand_OnFigurePluginChanged;
            SkinController.OnSkinChange += SkinController_OnSkinChange;
        }

        private void _xCommand_OnFigurePluginChanged()
        {
            Controls.Clear();
            Controls.Add(_emptyFigureGroupBox);

            if (_xCommand.ActiveFigurePlugin != null)
            {
                var pluginToolBox = _xCommand.ActiveFigurePlugin.GetToolBox();
                pluginToolBox.Parent = this;
                pluginToolBox.Location = new System.Drawing.Point(0, 160);
                pluginToolBox.Size = new System.Drawing.Size(Width - 10, 210);
                Controls.Add(pluginToolBox);
            }
        }

        private void Localization_OnLocalChange()
        {
            _emptyFigureGroupBox.Text = Localization.GetText("properties_text_id");
            _typeLbl.Text = Localization.GetText("types_text_id");
            _line.Text = Localization.GetText("line_text_id");
            _rect.Text = Localization.GetText("rectangle_text_id");
            _roundRect.Text = Localization.GetText("rounded_rectangle_text_id");
            _ellipse.Text = Localization.GetText("ellipse_text_id");
            _colorLbl.Text = Localization.GetText("color_text_id");
            _color.Text = Localization.GetText("color_text_id");
            _lineWidthLabel.Text = Localization.GetText("width_text_id");
        }

        private void SkinController_OnSkinChange()
        {
           // BackColor = SkinController.GetColor("primaryColor");
           // ForeColor = SkinController.GetColor("primaryTextColor");
        }


    }
}
