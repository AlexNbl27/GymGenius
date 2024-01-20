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
    public abstract class AExercise
    {
        public string name { get; protected set; }
        public string translatedName { get; protected set; }
        public string description { get; protected set; }
        public int level { get; protected set; }
        public float duration { get; protected set; } 
        public List<AEquipment> equipments { get; protected set; }
        public struct Tags
        {
            List<string> muscles;
            bool isAtHome;
        }
    }

    public class Pumps : AExercise
    {
        public Pumps()
        {
            name = "Pumps";
            translatedName = Utilities.Translate(name, "Name");
            description = Utilities.Translate(name, "Description");
            level = 1;
            duration = 0.5f;
            equipments = new List<AEquipment>();
        }
    }

    public class Abdominal : AExercise
    {
        public Abdominal()
        {
            name = "Abdominal";
            translatedName = Utilities.Translate(name, "Name");
            description = Utilities.Translate(name, "Description");
            level = 1;
            duration = 0.5f;
            equipments = new List<AEquipment>();
            equipments.Add(new FitnessMat());
        }
    }
}
