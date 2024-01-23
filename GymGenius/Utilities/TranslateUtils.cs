using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace GymGenius.Controller
{

    public static class TranslateUtils
    {
        public static string Translate(string className, string key)
        {
            string nameWithoutSpaces = className.Replace(" ", "");
            ResourceManager resManager = new(typeof(Properties.Resources));
            string lang = "FR";
            string resourcekey = nameWithoutSpaces + key + "_" + lang;
            return resManager.GetString(resourcekey);
        }
    }
}
