using Painter.Controllers;
using Painter.Models;
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
    public partial class PToolBar : ToolStrip
    {
        private IXCommand _xCommand = null;

        //File
        ToolStripLabel _fileLbl;
        ToolStripButton _saveBtn;
        ToolStripButton _loadBtn;

        //Tab
        ToolStripLabel _tabLbl;
        ToolStripButton _newTabBtn;
        ToolStripButton _delTabBtn;
        ToolStripButton _renameTabBtn;

        //Figure
        ToolStripLabel _figureLbl;
        ToolStripComboBox _typeCbx;
        ToolStripComboBox _widthCbx;
        ToolStripButton _colorBtn;

        // Figure: Type
        private ToolStripMenuItem _lineBtn;
        private ToolStripMenuItem _rectangleBtn;
        private ToolStripMenuItem _roundedRectangleBtn;
        private ToolStripMenuItem _ellipseBtn;

        // Figure: Width
        private ToolStripMenuItem _width1Btn;
        private ToolStripMenuItem _width5Btn;
        private ToolStripMenuItem _width10Btn;
        private ToolStripMenuItem _width15Btn;
        private ToolStripMenuItem _width20Btn;


        public PToolBar(IXCommand xCommand)
        {
            _xCommand = xCommand;

            //File
            _fileLbl = new ToolStripLabel(Localization.GetText("file_text_id"));
            _saveBtn = new ToolStripButton(Localization.GetText("save_text_id"), null, delegate { _xCommand.FileSave(); });
            _saveBtn.ToolTipText = Localization.GetText("save_text_id");
            _loadBtn = new ToolStripButton(Localization.GetText("load_text_id"), null, delegate { _xCommand.FileOpen(); });
            _loadBtn.ToolTipText = Localization.GetText("load_text_id");

            //Tab
            _tabLbl = new ToolStripLabel(Localization.GetText("tab_text_id"));
            _newTabBtn = new ToolStripButton(Localization.GetText("new_text_id"), null, delegate { _xCommand.NewTab(); });
            _delTabBtn = new ToolStripButton(Localization.GetText("del_text_id"), null, delegate { _xCommand.CloseTab(); });
            _renameTabBtn = new ToolStripButton(Localization.GetText("rename_text_id"), null, delegate { _xCommand.RenameTab(); });
            _newTabBtn.ToolTipText = Localization.GetText("new_text_id");
            _delTabBtn.ToolTipText = Localization.GetText("del_text_id");
            _renameTabBtn.ToolTipText = Localization.GetText("rename_text_id");

            //Figure
            _figureLbl = new ToolStripLabel(Localization.GetText("figure_text_id"));
            _typeCbx = new ToolStripComboBox();

            _lineBtn = new ToolStripMenuItem(Localization.GetText("line_text_id"), null, delegate { _xCommand.SetType(XData.FigureType.Line); });
            _rectangleBtn = new ToolStripMenuItem(Localization.GetText("rectangle_text_id"), null, delegate { _xCommand.SetType(XData.FigureType.Rectangle); });
            _roundedRectangleBtn = new ToolStripMenuItem(Localization.GetText("rounded_rectangle_text_id"), null, delegate { _xCommand.SetType(XData.FigureType.RoundRectangle); });
            _ellipseBtn = new ToolStripMenuItem(Localization.GetText("ellipse_text_id"), null, delegate { _xCommand.SetType(XData.FigureType.Ellipse); });


            _widthCbx = new ToolStripComboBox();

            _width1Btn = new ToolStripMenuItem("1", null, delegate { _xCommand.SetLineWidth(1); });
            _width5Btn = new ToolStripMenuItem("5", null, delegate { _xCommand.SetLineWidth(5); });
            _width10Btn = new ToolStripMenuItem("10", null, delegate { _xCommand.SetLineWidth(10); });
            _width15Btn = new ToolStripMenuItem("15", null, delegate { _xCommand.SetLineWidth(15); });
            _width20Btn = new ToolStripMenuItem("20", null, delegate { _xCommand.SetLineWidth(20); });


            _colorBtn = new ToolStripButton(Localization.GetText("color_text_id"), null, delegate
            {
                try
                {
                    _xCommand.SetColor(Utilities.GetColor());
                }
                catch { }
            });

            Items.Add(_fileLbl);
            Items.Add(_saveBtn);
            Items.Add(_loadBtn);
            Items.Add(new ToolStripSeparator());
            Items.Add(_tabLbl);
            Items.Add(_newTabBtn);
            Items.Add(_delTabBtn);
            Items.Add(_renameTabBtn);
            Items.Add(new ToolStripSeparator());

            Items.Add(_figureLbl);
            Items.Add(_typeCbx);
            _typeCbx.Items.Add(_lineBtn);
            _typeCbx.Items.Add(_rectangleBtn);
            _typeCbx.Items.Add(_roundedRectangleBtn);
            _typeCbx.Items.Add(_ellipseBtn);
            _typeCbx.SelectedItem=_lineBtn;

            Items.Add(_widthCbx);
            _widthCbx.Items.Add(_width1Btn);
            _widthCbx.Items.Add(_width5Btn);
            _widthCbx.Items.Add(_width10Btn);
            _widthCbx.Items.Add(_width15Btn);
            _widthCbx.Items.Add(_width20Btn);
            //_widthCbx.Items.Add(1);
            //_widthCbx.Items.Add(5);
            //_widthCbx.Items.Add(10);
            //_widthCbx.Items.Add(15);
            //_widthCbx.Items.Add(20);
            _widthCbx.SelectedItem = _width1Btn;
           // _widthCbx.Click += delegate { try { _xCommand.SetLineWidth(Int32.Parse(_widthCbx.SelectedText)); } catch { } };

            Items.Add(_colorBtn);

            Localization.OnLocalChange += Localization_OnLocalChange;
            SkinController.OnSkinChange += SkinController_OnSkinChange;
        }

        private void SkinController_OnSkinChange()
        {
            throw new NotImplementedException();
        }

        private void Localization_OnLocalChange()
        {
            //File
            _fileLbl.Text = Localization.GetText("file_text_id");
            _saveBtn.ToolTipText = Localization.GetText("save_text_id");
            _saveBtn.ToolTipText = Localization.GetText("load_text_id");

            //Tab
            _newTabBtn.Text = Localization.GetText("new_text_id");
            _delTabBtn.ToolTipText = Localization.GetText("del_text_id");
            _renameTabBtn.ToolTipText = Localization.GetText("rename_text_id");

            //Figure
            _figureLbl.Text = Localization.GetText("figure_text_id");
            _colorBtn.ToolTipText = Localization.GetText("color_text_id");
        }
    }
}
