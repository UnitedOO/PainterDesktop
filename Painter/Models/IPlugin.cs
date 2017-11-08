using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Models
{
    public interface IPlugin
    {
        string Name { get; }
        bool Enabled { get; set; }
    }
}
