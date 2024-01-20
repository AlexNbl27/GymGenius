using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using GymGenius.Controller;
using GymGenius.Properties;

namespace GymGenius.Models
{
    public abstract class AEquipment
    {
        public string name { get; protected set; }
        public string translatedName { get; protected set; }
    }

    public class FitnessMat : AEquipment
    {
        public FitnessMat()
        {
            name = "Fitness Mat";
            translatedName = Translate(name, "Name");
        }
    }


}
