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
    public partial class PFrame : Panel
    {
        public PFrame()
        {
            IXCommand xCommand = new XCommand();
            xCommand.InitializePluginManager();

          //  var primaryBackColor = SkinController.GetColor("primaryColor");

            TabControl tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;
            Controls.Add(tabControl);

            xCommand.TabControl = tabControl;

            PElements pElements = new PElements(xCommand);
            pElements.Dock = DockStyle.Left;
          //  pElements.BackColor = primaryBackColor;
            pElements.Width = 150;
            Controls.Add(pElements);

            PToolBox pToolBox = new PToolBox(xCommand);
            pToolBox.Dock = DockStyle.Right;
           // pToolBox.BackColor = primaryBackColor;
            pToolBox.Width = 155;
            Controls.Add(pToolBox);

            PToolBar pToolBar = new PToolBar(xCommand);
           // pToolBar.BackColor = primaryBackColor;
            pToolBar.Dock = DockStyle.Top;
            Controls.Add(pToolBar);

            PMainMenu pMainMenu = new PMainMenu(xCommand);
            pMainMenu.Dock = DockStyle.Top;
          //  pMainMenu.BackColor = primaryBackColor;
            pMainMenu.Height = 50;
            Controls.Add(pMainMenu);

            PStatusBar pStatusBar = new PStatusBar(xCommand);
            pStatusBar.Dock = DockStyle.Bottom;
           // pStatusBar.BackColor = primaryBackColor;
            Controls.Add(pStatusBar); InitializeComponent();
        }

    }
}
