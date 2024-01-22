using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GymGenius.Controller;
using GymGenius.Controllers;
using GymGenius.Properties;

namespace GymGenius.Models
{
    public abstract class AExercise
    {
        protected string idname;
        public string translatedName { get; protected set; }
        public string description { get; protected set; }
        public ValueController level { get; protected set; }
        public TimeController duration { get; protected set; } 
        public List<AEquipment> equipments { get; protected set; }
        public struct Tags
        {
            List<AMuscles> muscles;
            bool isAtHome;
        }
    }

    public class Pumps : AExercise
    {
        public Pumps()
        {
            idname = "Pumps";
            translatedName = Utilities.Translate(idname, "Name");
            description = Utilities.Translate(idname, "Description");
            level.value = 1;
            duration.setTime("00:00:30");
            equipments = new List<AEquipment>();
        }
    }

    public class Abdominal : AExercise
    {
        public Abdominal()
        {
            idname = "Abdominal";
            translatedName = Utilities.Translate(idname, "Name");
            description = Utilities.Translate(idname, "Description");
            level.value = 1;
            duration.setTime(0,0,30);
            equipments = new List<AEquipment>();
            equipments.Add(new FitnessMat());
        }
    }
}
