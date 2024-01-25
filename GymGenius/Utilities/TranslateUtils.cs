using System.Globalization;
using System.Resources;

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

        public static string? GetRessourceName(string targetValue)
        {
            ResourceManager resManager = new(typeof(Properties.Resources));
            string lang = "FR";

            // Get all resource set names (e.g., language-specific)
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                ResourceSet resourceSet = resManager.GetResourceSet(ci, true, false);

                if (resourceSet != null)
                {
                    // Iterate through each resource in the set
                    foreach (System.Collections.DictionaryEntry entry in resourceSet)
                    {
                        // Check if the value matches the target value
                        if (entry.Value.ToString() == targetValue)
                        {
                            // Remove the "Name" and "_FR" suffixes from the key
                            string key = entry.Key.ToString();
                            string toBeRemoved = "Name_" + lang;
                            key = key.Replace(toBeRemoved, "").TrimEnd('_');

                            // Return the modified key if found
                            return key;
                        }
                    }
                }
            }
            return null;
        }

    }
}
