using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        Tags tags = new Tags();
        public struct Tags
        {
            List<AMuscles> Muscles;
            bool isAtHome;
        }

        public AExercise()
        {
            Level = new ValueController();
            Duration = new TimeController(new DateTime());
        }
    }

    public interface ICountable
    {
        public int NbRepetitions { get; set; }
    }

    public class PushUps : AExercise, ICountable
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
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level.value = 1;
            Duration.setTime(0,0,30);
            Equipments = new List<AEquipment>();
            Equipments.Add(new FitnessMat());
            Type = new Strength();
        }
    }
}
