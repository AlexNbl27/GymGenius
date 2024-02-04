using GymGenius.Controller;

namespace GymGenius.Models
{
    public abstract class AMuscle
    {
        protected string idname;
        public string Name { get; protected set; }

        public ABodyPart bodyPart;
    }

    public class Biceps : AMuscle
    {
        public Biceps()
        {
            idname = "Biceps";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Arms();
        }
    }

    public class Triceps : AMuscle
    {
        public Triceps()
        {
            idname = "Triceps";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Arms();
        }
    }

    public class Quadriceps : AMuscle
    {
        public Quadriceps()
        {
            idname = "Quadriceps";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Legs();
        }
    }

    public class Hamstrings : AMuscle
    {
        public Hamstrings()
        {
            idname = "Hamstrings";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Legs();
        }
    }

    public class Glutes : AMuscle
    {
        public Glutes()
        {
            idname = "Glutes";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Legs();
        }
    }

    public class Trapezius : AMuscle
    {
        public Trapezius()
        {
            idname = "Trapezius";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Shoulders();
        }
    }

    public class Deltoids : AMuscle
    {
        public Deltoids()
        {
            idname = "Deltoids";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Shoulders();
        }
    }

    public class Pectorals : AMuscle
    {
        public Pectorals()
        {
            idname = "Pectorals";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Trunk();
        }
    }

    public class Abdominals : AMuscle
    {
        public Abdominals()
        {
            idname = "Abdominals";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Trunk();
        }
    }

    public class Obliques : AMuscle
    {
        public Obliques()
        {
            idname = "Obliques";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Trunk();
        }
    }

    public class Calves : AMuscle
    {
        public Calves()
        {
            idname = "Calves";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Legs();
        }
    }

    public class Abductors : AMuscle
    {
        public Abductors()
        {
            idname = "Abductors";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Legs();
        }
    }

    public class LargeDorsals : AMuscle
    {
        public LargeDorsals()
        {
            idname = "LargeDorsals";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Back();
        }
    }

    public class SmallDorsals : AMuscle
    {
        public SmallDorsals()
        {
            idname = "SmallDorsals";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Back();
        }
    }

    public class Forearms : AMuscle
    {
        public Forearms()
        {
            idname = "Forearms";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Arms();
        }
    }

    public class Neck : AMuscle
    {
        public Neck()
        {
            idname = "Neck";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Trunk();
        }
    }

    public class Transerves : AMuscle
    {
        public Transerves()
        {
            idname = "Transerves";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Trunk();
        }
    }

    public class RotatorCuff : AMuscle
    {
        public RotatorCuff()
        {
            idname = "RotatorCuff";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Shoulders();
        }
    }

    public class Rhomboids : AMuscle
    {
        public Rhomboids()
        {
            idname = "Rhomboids";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Back();
        }
    }
}
