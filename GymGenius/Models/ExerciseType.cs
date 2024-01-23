using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymGenius.Controller;

namespace GymGenius.Models
{
    public abstract class AExerciseType
    {
        protected string idname;
        public string Name { get; protected set; }
    }

    public class Cardio : AExerciseType
    {
        public Cardio()
        {
            idname = "Cardio";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class Strength : AExerciseType
    {
        public Strength()
        {
            idname = "Strength";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class Stretching : AExerciseType
    {
        public Stretching()
        {
            idname = "Stretching";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }
}
