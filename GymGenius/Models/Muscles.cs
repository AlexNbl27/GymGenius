using GymGenius.Controller;

namespace GymGenius.Models
{
    public abstract class AMuscles
    {
        protected string idname;
        public string Name { get; protected set; }

        public ABodyPart bodyPart;
    }

    public class Biceps : AMuscles
    {
        public Biceps()
        {
            idname = "Biceps";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Arms();
        }
    }

    public class Triceps : AMuscles
    {
        public Triceps()
        {
            idname = "Triceps";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Arms();
        }
    }

    public class Quadriceps : AMuscles
    {
        public Quadriceps()
        {
            idname = "Quadriceps";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Legs();
        }
    }

    public class Hamstrings : AMuscles
    {
        public Hamstrings()
        {
            idname = "Hamstrings";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Legs();
        }
    }

    public class Glutes : AMuscles
    {
        public Glutes()
        {
            idname = "Glutes";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Legs();
        }
    }

    public class Trapezius : AMuscles
    {
        public Trapezius()
        {
            idname = "Trapezius";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Shoulders();
        }
    }

    public class Deltoids : AMuscles
    {
        public Deltoids()
        {
            idname = "Deltoids";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Shoulders();
        }
    }

    public class Pectorals : AMuscles
    {
        public Pectorals()
        {
            idname = "Pectorals";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Trunk();
        }
    }

    public class Abdominals : AMuscles
    {
        public Abdominals()
        {
            idname = "Abdominals";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Trunk();
        }
    }

    public class Obliques : AMuscles
    {
        public Obliques()
        {
            idname = "Obliques";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Trunk();
        }
    }

    public class Calves : AMuscles
    {
        public Calves()
        {
            idname = "Calves";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Legs();
        }
    }

    public class Abductors : AMuscles
    {
        public Abductors()
        {
            idname = "Abductors";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Legs();
        }
    }

    public class LargeDorsals : AMuscles
    {
        public LargeDorsals()
        {
            idname = "LargeDorsals";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Back();
        }
    }

    public class SmallDorsals : AMuscles
    {
        public SmallDorsals()
        {
            idname = "SmallDorsals";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Back();
        }
    }

    public class Forearms : AMuscles
    {
        public Forearms()
        {
            idname = "Forearms";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Arms();
        }
    }

    public class Neck : AMuscles
    {
        public Neck()
        {
            idname = "Neck";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Trunk();
        }
    }

    public class Transerves : AMuscles
    {
        public Transerves()
        {
            idname = "Transerves";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Trunk();
        }
    }

    public class RotatorCuff : AMuscles
    {
        public RotatorCuff()
        {
            idname = "RotatorCuff";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Shoulders();
        }
    }

    public class Rhomboids : AMuscles
    {
        public Rhomboids()
        {
            idname = "Rhomboids";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Back();
        }
    }
}
