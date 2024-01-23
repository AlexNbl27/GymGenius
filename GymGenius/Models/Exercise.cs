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
        public List<AEquipment> Equipments { get; protected set; } = new List<AEquipment>();

        public AExerciseType Type { get; protected set; }
        public struct Tags
        {
            public List<AMuscles> Muscles;
            public bool isAtHome;
        }
    }

    public interface ISerie
    {
        public int NbRepetitions { get; set; }
    }

    public class Dips : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }

        public Dips()
        {
            idname = "Squat";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level.value = 3;
            Duration.setTime("00:00:03");
            Equipments.Add(new DoublesBars());
            Equipments.Add(new MachineDips());
            Type = new Muscular();
            Tags tags = new Tags();
            tags.Muscles = new List<AMuscles>();
            tags.Muscles.Add(new Triceps());
            tags.Muscles.Add();
        }
    }
}
