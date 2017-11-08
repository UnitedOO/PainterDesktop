using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Controllers
{
    public class Localization
    {
        private static string currLocale = "en";
        public static string Locale { set { currLocale = value; OnLocalChange(); } }

        public delegate void OnLocalChangeDelegate();
        public static event OnLocalChangeDelegate OnLocalChange;

        public static string GetText(string id)
        {
            string locFile = "";
            if (currLocale == "en")
                locFile = "Locale/locale_en.json";
            else
                locFile = "Locale/locale_ru.json";

            string res = "ID NOT FOUND";
            using (StreamReader streamReader = new StreamReader(locFile))
            {
                JToken token = JObject.Parse(streamReader.ReadToEnd());
                res = token[id].ToString();
            }

            return res;
        }
    }
}
