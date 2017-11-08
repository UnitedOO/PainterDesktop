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
    public partial class PMainMenu : MenuStrip
    {
        private IXCommand _xCommand = null;

        // MainMenu
        private ToolStripMenuItem _fileBtn;
        private ToolStripMenuItem _figureBtn;
        private ToolStripMenuItem _viewBtn;
        private ToolStripMenuItem _tabBtn;
        private ToolStripMenuItem _pagesBtn;
        private ToolStripMenuItem _languageBtn;
        private ToolStripMenuItem _figurePluginsBtn;
        private ToolStripMenuItem _formatPluginsBtn;
        private ToolStripMenuItem _cloudBtn;
        private ToolStripMenuItem _skinsBtn;
        private ToolStripMenuItem _helpBtn;

        // MainMenu: File
        private ToolStripMenuItem _saveBtn;
        private ToolStripMenuItem _openBtn;
        private ToolStripMenuItem _exitBtn;

        // MainMenu: Figure
        private ToolStripMenuItem _typeBtn;
        private ToolStripMenuItem _colorBtn;
        private ToolStripMenuItem _widthBtn;

        // MainMenu: Figure: Type
        private ToolStripMenuItem _lineBtn;
        private ToolStripMenuItem _rectangleBtn;
        private ToolStripMenuItem _roundedRectangleBtn;
        private ToolStripMenuItem _ellipseBtn;

        // MainMenu: Figure: Width
        private ToolStripMenuItem _width1Btn;
        private ToolStripMenuItem _width5Btn;
        private ToolStripMenuItem _width10Btn;
        private ToolStripMenuItem _width15Btn;
        private ToolStripMenuItem _width20Btn;

        // MainMenu: View
        private ToolStripMenuItem _toolBarBtn;
        private ToolStripMenuItem _propertiesBtn;

        // MainMenu: Tab
        private ToolStripMenuItem _newTabBtn;
        private ToolStripMenuItem _renameTabBtn;
        private ToolStripMenuItem _closeTabBtn;

        // MainMenu: Pages

        // MainMenu: Language
        private ToolStripMenuItem _russianBtn;
        private ToolStripMenuItem _englishBtn;
        private ToolStripMenuItem _ukrainianBtn;

        // MainMenu: Figure Plugins
        private ToolStripMenuItem _simpleFigureBtn;

        // MainMenu: Format Plugins
        private ToolStripMenuItem _jsonFormatBtn;
        private ToolStripMenuItem _xmlFormatBtn;
        private ToolStripMenuItem _yamlFormatBtn;

        // MainMenu: Cloud
        private ToolStripMenuItem _saveInCloudBtn;
        private ToolStripMenuItem _loadFromCloudBtn;

        // MainMenu: Skins
        private ToolStripMenuItem _skin1Btn;
        private ToolStripMenuItem _skin2Btn;
        private ToolStripMenuItem _skin3Btn;

        // MainMenu: Help
        private ToolStripMenuItem _faqBtn;
        private ToolStripMenuItem _aboutBtn;

        public PMainMenu(IXCommand xCommand)
        {
            _xCommand = xCommand;

            // MainMenu
            _fileBtn = new ToolStripMenuItem(Localization.GetText("file_text_id"));
            _figureBtn = new ToolStripMenuItem(Localization.GetText("figure_text_id"));
            _viewBtn = new ToolStripMenuItem(Localization.GetText("view_text_id"));
            _tabBtn = new ToolStripMenuItem(Localization.GetText("tab_text_id"));
            _pagesBtn = new ToolStripMenuItem(Localization.GetText("pages_text_id"));
            _languageBtn = new ToolStripMenuItem(Localization.GetText("language_text_id"));
            _figurePluginsBtn = new ToolStripMenuItem(Localization.GetText("figure_plugins_text_id"));
            _formatPluginsBtn = new ToolStripMenuItem(Localization.GetText("format_plugins_text_id"));
            _cloudBtn = new ToolStripMenuItem(Localization.GetText("cloud_text_id"));
            _skinsBtn = new ToolStripMenuItem(Localization.GetText("skins_text_id"));
            _helpBtn = new ToolStripMenuItem(Localization.GetText("help_text_id"));

            // MainMenu: File
            _saveBtn = new ToolStripMenuItem(Localization.GetText("save_text_id"), null, delegate { _xCommand.FileSave(); });
            _openBtn = new ToolStripMenuItem(Localization.GetText("open_text_id"), null, delegate { _xCommand.FileOpen(); });
            _exitBtn = new ToolStripMenuItem(Localization.GetText("exit_text_id"), null, delegate { _xCommand.Exit(); });

            // MainMenu: Figure
            _typeBtn = new ToolStripMenuItem(Localization.GetText("types_text_id"));
            _colorBtn = new ToolStripMenuItem(Localization.GetText("color_text_id"), null, delegate
            {
                try
                {
                    _xCommand.SetColor(Utilities.GetColor());
                }
                catch { }
            });
            _widthBtn = new ToolStripMenuItem(Localization.GetText("width_text_id"));

            // MainMenu: Figure: Type
            _lineBtn = new ToolStripMenuItem(Localization.GetText("line_text_id"), null, delegate { _xCommand.SetType(XData.FigureType.Line); });
            _rectangleBtn = new ToolStripMenuItem(Localization.GetText("rectangle_text_id"), null, delegate { _xCommand.SetType(XData.FigureType.Rectangle); });
            _roundedRectangleBtn = new ToolStripMenuItem(Localization.GetText("rounded_rectangle_text_id"), null, delegate { _xCommand.SetType(XData.FigureType.RoundRectangle); });
            _ellipseBtn = new ToolStripMenuItem(Localization.GetText("ellipse_text_id"), null, delegate { _xCommand.SetType(XData.FigureType.Ellipse); });

            // MainMenu: Figure: Width
            _width1Btn = new ToolStripMenuItem("1", null, delegate { _xCommand.SetLineWidth(1); });
            _width5Btn = new ToolStripMenuItem("5", null, delegate { _xCommand.SetLineWidth(5); });
            _width10Btn = new ToolStripMenuItem("10", null, delegate { _xCommand.SetLineWidth(10); });
            _width15Btn = new ToolStripMenuItem("15", null, delegate { _xCommand.SetLineWidth(15); });
            _width20Btn = new ToolStripMenuItem("20", null, delegate { _xCommand.SetLineWidth(20); });

            // MainMenu: View
            _toolBarBtn = new ToolStripMenuItem(Localization.GetText("tool_bar_text_id"), null, delegate { _xCommand.AddToolBar(); });
            _propertiesBtn = new ToolStripMenuItem(Localization.GetText("properties_text_id"), null, delegate { _xCommand.AddProperties(); });

            // MainMenu: Tab
            _newTabBtn = new ToolStripMenuItem(Localization.GetText("new_tab_text_id"), null, delegate { _xCommand.NewTab(); });
            _renameTabBtn = new ToolStripMenuItem(Localization.GetText("rename_tab_text_id"), null, delegate { _xCommand.RenameTab(); });
            _closeTabBtn = new ToolStripMenuItem(Localization.GetText("close_tab_text_id"), null, delegate { _xCommand.CloseTab(); });

            // MainMenu: Language
            _russianBtn = new ToolStripMenuItem(Localization.GetText("russian_text_id"), null, delegate { _xCommand.RussianLanguage(); });
            _englishBtn = new ToolStripMenuItem(Localization.GetText("english_text_id"), null, delegate { _xCommand.EnglishLanguage(); });
            _ukrainianBtn = new ToolStripMenuItem(Localization.GetText("ukrainian_text_id"), null, delegate { _xCommand.UkrainianLanguage(); });

            // MainMenu: Figure Plugins
            _simpleFigureBtn = new ToolStripMenuItem(Localization.GetText("simple_figure_text_id"), null, delegate { _xCommand.SimpleFigure(); });

            // MainMenu: Format Plugins
            //_jsonFormatBtn = new ToolStripMenuItem(Localization.GetText("json_text_id"), null, delegate { _xCommand.AddJSON(); });
            //_xmlFormatBtn = new ToolStripMenuItem(Localization.GetText("xml_text_id"), null, delegate { _xCommand.AddXML(); });
            //_yamlFormatBtn = new ToolStripMenuItem(Localization.GetText("yaml_text_id"), null, delegate { _xCommand.AddYAML(); });

            // MainMenu: Cloud
            _saveInCloudBtn = new ToolStripMenuItem(Localization.GetText("save_text_id"), null, delegate { _xCommand.SaveInCloud(); });
            _loadFromCloudBtn = new ToolStripMenuItem(Localization.GetText("load_from_cloud_text_id"), null, delegate { _xCommand.OpenFromCloud(); });

            // MainMenu: Skins
            _skin1Btn = new ToolStripMenuItem(Localization.GetText("skin1_text_id"), null, delegate { _xCommand.Skin1(); });
            _skin2Btn = new ToolStripMenuItem(Localization.GetText("skin2_text_id"), null, delegate { _xCommand.Skin2(); });
            _skin3Btn = new ToolStripMenuItem(Localization.GetText("skin2_text_id"), null, delegate { _xCommand.Skin3(); });

            // MainMenu: Help
            _faqBtn = new ToolStripMenuItem(Localization.GetText("faq_text_id"), null, delegate { _xCommand.ShowFAQ(); });
            _aboutBtn = new ToolStripMenuItem(Localization.GetText("about_text_id"), null, delegate { _xCommand.ShowAbout(); });

            FillMenu();

            Localization.OnLocalChange += Localization_OnLocalChange;
            _xCommand.OnFigurePluginChanged += _xCommand_OnFigurePluginChanged;
            SkinController.OnSkinChange += SkinController_OnSkinChange;
        }

        private void SkinController_OnSkinChange()
        {
            throw new NotImplementedException();
        }

        private void _xCommand_OnFigurePluginChanged()
        {
            _figurePluginsBtn.DropDownItems.Clear();

            if (_xCommand.ActiveFigurePlugin != null)
                _figurePluginsBtn.DropDownItems.Add(_xCommand.ActiveFigurePlugin.GetMenuStrip());

            _figurePluginsBtn.DropDownItems.Add(_figureBtn);
        }

        private void FillMenu()
        {
            Items.Clear();

            // MainMenu
            Items.Add(_fileBtn);
            Items.Add(_figureBtn);
            Items.Add(_viewBtn);
            Items.Add(_tabBtn);
            Items.Add(_pagesBtn);
            Items.Add(_languageBtn);
            Items.Add(_figurePluginsBtn);
            Items.Add(_formatPluginsBtn);
            Items.Add(_cloudBtn);
            Items.Add(_skinsBtn);
            Items.Add(_helpBtn);


            // MainMenu: FileItems
            _fileBtn.DropDownItems.Add(_saveBtn);
            _fileBtn.DropDownItems.Add(_openBtn);
            _fileBtn.DropDownItems.Add(_exitBtn);

            // MainMenu: Figure
            _figureBtn.DropDownItems.Add(_typeBtn);
            _figureBtn.DropDownItems.Add(_colorBtn);
            _figureBtn.DropDownItems.Add(_widthBtn);

            // MainMenu: Figure: Type
            _typeBtn.DropDownItems.Add(_lineBtn);
            _typeBtn.DropDownItems.Add(_rectangleBtn);
            _typeBtn.DropDownItems.Add(_roundedRectangleBtn);
            _typeBtn.DropDownItems.Add(_ellipseBtn);
            _lineBtn.Checked = true;

            // MainMenu: Figure: Width
            _widthBtn.DropDownItems.Add(_width1Btn);
            _widthBtn.DropDownItems.Add(_width5Btn);
            _widthBtn.DropDownItems.Add(_width10Btn);
            _widthBtn.DropDownItems.Add(_width15Btn);
            _widthBtn.DropDownItems.Add(_width20Btn);
            _width1Btn.Checked = true;

            // MainMenu: View
            _viewBtn.DropDownItems.Add(_toolBarBtn);
            _viewBtn.DropDownItems.Add(_propertiesBtn);
            _toolBarBtn.Checked = true;//?
            _propertiesBtn.Checked = true;//?

            // MainMenu: Tab
            _tabBtn.DropDownItems.Add(_newTabBtn);
            _tabBtn.DropDownItems.Add(_renameTabBtn);
            _tabBtn.DropDownItems.Add(_closeTabBtn);

            // MainMenu: Pages

            // MainMenu: Language
            _languageBtn.DropDownItems.Add(_russianBtn);
            _languageBtn.DropDownItems.Add(_englishBtn);
            _languageBtn.DropDownItems.Add(_ukrainianBtn);
            _englishBtn.Checked = true;

            // MainMenu: Figure Plugins
            _figurePluginsBtn.DropDownItems.Add(_simpleFigureBtn);
            _simpleFigureBtn.Checked = true;
            foreach (IPluginFigure plugin in _xCommand.FigurePlugins)
            {
                var toolStripMenuItem = new ToolStripMenuItem(plugin.Name, null, delegate { _xCommand.TogglePlugin(plugin); });
                toolStripMenuItem.CheckOnClick = true;
                _figurePluginsBtn.DropDownItems.Add(toolStripMenuItem);
            }

            // MainMenu: Format Plugins
            foreach (IPluginFile plugin in _xCommand.FilePlugins)
            {
                _formatPluginsBtn.DropDownItems.Add(plugin.Name);
            }

            // MainMenu: Cloud
            _cloudBtn.DropDownItems.Add(_saveInCloudBtn);
            _cloudBtn.DropDownItems.Add(_loadFromCloudBtn);

            // MainMenu: Skins
            _skinsBtn.DropDownItems.Add(_skin1Btn);
            _skinsBtn.DropDownItems.Add(_skin2Btn);
            _skinsBtn.DropDownItems.Add(_skin3Btn);
            _skin1Btn.Checked = true;

            // MainMenu: HelpItems
            _helpBtn.DropDownItems.Add(_faqBtn);
            _helpBtn.DropDownItems.Add(_aboutBtn);
        }

        private void Localization_OnLocalChange()
        {
            // MainMenu
            _fileBtn.Text = Localization.GetText("file_text_id");
            _figureBtn.Text = Localization.GetText("figure_text_id");
            _viewBtn.Text = Localization.GetText("view_text_id");
            _tabBtn.Text = Localization.GetText("tab_text_id");
            _pagesBtn.Text = Localization.GetText("pages_text_id");
            _languageBtn.Text = Localization.GetText("language_text_id");
            _figurePluginsBtn.Text = Localization.GetText("figure_plugins_text_id");
            _formatPluginsBtn.Text = Localization.GetText("format_plugins_text_id");
            _cloudBtn.Text = Localization.GetText("cloud_text_id");
            _skinsBtn.Text = Localization.GetText("skins_text_id");
            _helpBtn.Text = Localization.GetText("help_text_id");

            // MainMenu: File
            _saveBtn.Text = Localization.GetText("save_text_id");
            _openBtn.Text = Localization.GetText("open_text_id");
            _exitBtn.Text = Localization.GetText("exit_text_id");

            // MainMenu: Figure
            _typeBtn.Text = Localization.GetText("types_text_id");
            _colorBtn.Text = Localization.GetText("color_text_id");
            _widthBtn.Text = Localization.GetText("width_text_id");

            // MainMenu: Figure: Type
            _lineBtn.Text = Localization.GetText("line_text_id");
            _rectangleBtn.Text = Localization.GetText("rectangle_text_id");
            _roundedRectangleBtn.Text =Localization.GetText("rounded_rectangle_text_id");
            _ellipseBtn.Text = Localization.GetText("ellipse_text_id");
                        
            // MainMenu: View
            _toolBarBtn.Text =Localization.GetText("tool_bar_text_id");
            _propertiesBtn.Text = Localization.GetText("properties_text_id");

            // MainMenu: Tab
            _newTabBtn.Text = Localization.GetText("new_tab_text_id");
            _renameTabBtn.Text = Localization.GetText("rename_tab_text_id");
            _closeTabBtn.Text = Localization.GetText("close_tab_text_id");

            // MainMenu: Language
            _russianBtn.Text =Localization.GetText("russian_text_id");
            _englishBtn.Text = Localization.GetText("english_text_id");
            _ukrainianBtn.Text = Localization.GetText("ukrainian_text_id");

            // MainMenu: Figure Plugins
            _simpleFigureBtn.Text = Localization.GetText("simple_figure_text_id");

            // MainMenu: Cloud
            _saveInCloudBtn.Text = Localization.GetText("save_text_id");
            _loadFromCloudBtn.Text = Localization.GetText("load_from_cloud_text_id");

            // MainMenu: Skins
            _skin1Btn.Text = Localization.GetText("skin1_text_id");
            _skin2Btn.Text = Localization.GetText("skin2_text_id");
            _skin3Btn.Text = Localization.GetText("skin2_text_id");

            // MainMenu: Help
            _faqBtn.Text = Localization.GetText("faq_text_id");
            _aboutBtn.Text = Localization.GetText("about_text_id");

        }
    }
}
