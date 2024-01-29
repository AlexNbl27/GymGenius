using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Documents;
using GymGenius.Models;

namespace GymGenius.Utilities
{
    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<AMuscles> muscles)
            {
                return string.Join(", ", muscles.Select(muscle => muscle.Name));
            }
            else if (value is IEnumerable<AEquipment> equipments)
            {
                return string.Join(", ", equipments.Select(equipment => equipment.Name));
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public static  class FuncsExtend 
    {
        public static string ConvertListToString(this List<AMuscles> muscles )
        {
            string result = "";
            foreach (var muscle in muscles)
            {
                result += muscle.Name + ", ";
            }
            return result;
        }
    }
}