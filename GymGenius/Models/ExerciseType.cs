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

    public class Muscular : AExerciseType
    {
        public Muscular()
        {
            idname = "Muscular";
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
