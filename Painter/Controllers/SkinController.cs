using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Controllers
{
    class SkinController
    {
        private static string currSkin = "light";
        public static string Skin { set { currSkin = value; OnSkinChange(); } }

        public delegate void OnLocalChangeDelegate();
        public static event OnLocalChangeDelegate OnSkinChange;

        //public static Color GetColor(string id)
        //{
        //    string skinFile = "";
        //    if (currSkin == "dark")
        //        skinFile = "Skins/DarkSkin.json";
        //    else
        //        skinFile = "Skins/LightSkin.json";


        //    string res = "ID NOT FOUND";
        //    using (StreamReader streamReader = new StreamReader(skinFile))
        //    {
        //        JToken token = JObject.Parse(streamReader.ReadToEnd());
        //        res = token[id].ToString();
        //    }

        //    return Color.FromArgb(int.Parse(res.Substring(1), System.Globalization.NumberStyles.HexNumber));
        //}
    }
}
