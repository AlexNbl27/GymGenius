using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public class Claves : AMuscles
    {
        public Claves()
        {
            idname = "Claves";
            Name = TranslateUtils.Translate(idname, "Name");
            bodyPart = new Trunk();
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
}
 