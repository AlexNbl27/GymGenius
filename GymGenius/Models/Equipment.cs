using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GymGenius.Controller;
using GymGenius.Properties;

namespace GymGenius.Models
{
    public abstract class AEquipment
    {
        protected string idname;
        public string Name { get; protected set; }
    }

    public class FitnessMat : AEquipment
    {
        public FitnessMat()
        {
            idname = "Fitness Mat";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }


}
