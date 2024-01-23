using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
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
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public ValueController Level { get; protected set; }
        public TimeController Duration { get; protected set; } 
        public List<AEquipment> Equipments { get; protected set; }

        public AExerciseType Type { get; protected set; }
        public struct Tags
        {
            List<AMuscles> Muscles;
            bool isAtHome;
        }
    }

    public interface ISerie
    {
        public int NbRepetitions { get; set; }
    }

    public class PushUps : AExercise, ISerie
    {

        public int NbRepetitions { get; set; }

        public PushUps()
        {
            idname = "PushUps";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level.value = 1;
            Duration.setTime("00:00:30");
            Equipments = new List<AEquipment>();
            Type = new Strength();
        }
    }

    public class Abdominal : AExercise
    {
        public Abdominal()
        {
            idname = "Abdominal";
            translatedName = TranslateUtils.Translate(idname, "Name");
            description = TranslateUtils.Translate(idname, "Description");
            level.value = 1;
            duration.setTime(0,0,30);
            equipments = new List<AEquipment>();
            equipments.Add(new FitnessMat());
            type = new Strength();
        }
    }
}
