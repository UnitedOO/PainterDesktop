using Painter.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Width = 920;
            Height = 680;
            PFrame pFrame = new PFrame();
            pFrame.Dock = DockStyle.Fill;
            Controls.Add(pFrame);
        }
    }
}
