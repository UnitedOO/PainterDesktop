using Painter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Controllers
{
    public class PluginManager
    {
        public List<IPluginFigure> figurePlugins = new List<IPluginFigure>();
        public List<IPluginFile> formatPlugins = new List<IPluginFile>();

        public PluginManager()
        {
            LoadPlugins();
        }

        public void LoadPlugins()
        {
            figurePlugins.Clear();
            formatPlugins.Clear();

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
            {
                Assembly assembly = Assembly.LoadFile(dll);
                Type[] plugins = assembly.GetTypes().Where(x => x.GetInterface(typeof(IPlugin).Name) != null).ToArray();

                Debug.WriteLine("Available Plugins:");
                foreach (Type pluginType in plugins)
                {
                    if (pluginType.GetInterface(typeof(IPluginFigure).Name) != null)
                        figurePlugins.Add(Activator.CreateInstance(pluginType) as IPluginFigure);
                    else if (pluginType.GetInterface(typeof(IPluginFile).Name) != null)
                        formatPlugins.Add(Activator.CreateInstance(pluginType) as IPluginFile);
                    Debug.WriteLine(pluginType.Name);
                }
            }
        }
    }
}
