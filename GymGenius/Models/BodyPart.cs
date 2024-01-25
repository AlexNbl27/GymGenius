using GymGenius.Controller;

namespace GymGenius.Models
{
    public abstract class ABodyPart
    {
        protected string idname;
        public string Name { get; protected set; }
    }

    public class Arms : ABodyPart
    {
        public Arms()
        {
            idname = "Arms";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class Legs : ABodyPart
    {
        public Legs()
        {
            idname = "Legs";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class Back : ABodyPart
    {
        public Back()
        {
            idname = "Back";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class Trunk : ABodyPart
    {
        public Trunk()
        {
            idname = "Trunk";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class Shoulders : ABodyPart
    {
        public Shoulders()
        {
            idname = "Shoulders";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }
}
