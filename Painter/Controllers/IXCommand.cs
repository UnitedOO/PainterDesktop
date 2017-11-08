using Painter.Models;
using Painter.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter.Controllers
{
    public interface IXCommand
    {
        PFigure ActiveFigure { get; set; }
        IPluginFigure ActiveFigurePlugin { get; set; }
        List<IPluginFigure> FigurePlugins { get; }
        List<IPluginFile> FilePlugins { get; }
        TabControl TabControl { get; set; }

        event Action OnFigurePluginChanged;

        void InitializePluginManager();
        PFigure PluginProcess(PFigure figure);

        void FileOpen();
        void FileSave();
        void Exit();

        void NewTab();
        void CloseTab();
        void RenameTab();

        void OpenFromCloud();
        void SaveInCloud();

        void ShowAbout();
        void ShowFAQ();

        void SimpleFigure();

        void RussianLanguage();
        void EnglishLanguage();
        void UkrainianLanguage();

        void Skin1();
        void Skin2();
        void Skin3();

        void ToggleVisible(Control control);
        void SetType(XData.FigureType type);
        void SetColor(Color color);
        void SetLineWidth(int width);
        void TogglePlugin(IPluginFigure plugin);

        void AddToolBar();
        void AddProperties();
    }
}
