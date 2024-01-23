using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Linq;
using GymGenius.Controller;
using GymGenius.Properties;

namespace GymGenius.Models
{
    public abstract class AEquipment
    {
        protected string idname;
        public string Name { get; protected set; }
    }

    public class FitnessMat : AEquipment
    {
        public FitnessMat()
        {
            idname = "Fitness Mat";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class DoublesBars : AEquipment
    {
        public DoublesBars()
        {
            idname = "Doubles Bars";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class MachineDips : AEquipment
    {
        public MachineDips()
        {
            idname = "Machine Dips";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class WeightBench : AEquipment
    {
        public WeightBench()
        {
            idname = "Weight Bench";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class Dumbbells : AEquipment
    {
        public Dumbbells()
        {
            idname = "Dumbbells";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class CurlBar : AEquipment
    {
        public CurlBar()
        {
            idname = "Curl Bar";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class HighPulley : AEquipment
    {
        public HighPulley()
        {
            idname = "High Pulley";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class LowPulley : AEquipment
    {
        public LowPulley()
        {
            idname = "Low Pulley";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class DoublePulley : AEquipment
    {
        public DoublePulley()
        {
            idname = "Double Pulley";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class MachinePecDeck : AEquipment
    {
        public MachinePecDeck()
        {
            idname = "Machine Pec Deck";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class Pulley : AEquipment
    {
        public Pulley()
        {
            idname = "Pulley";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class WeightBar : AEquipment
    {
        public WeightBar()
        {
            idname = "Weight Bar";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class WeightDiscus : AEquipment
    {
        public WeightDiscus()
        {
            idname = "Weight Discus";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class Weights : AEquipment
    {
        public Weights()
        {
            idname = "Weights";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class Press : AEquipment
    {
        public Press()
        {
            idname = "Press";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class MachineLegExtension : AEquipment
    {
        public MachineLegExtension()
        {
            idname = "Machine Leg Extension";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class MachineLegCurl : AEquipment
    {
        public MachineLegCurl()
        {
            idname = "Machine Leg Curl";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class CalfPressMachine : AEquipment
    {
        public CalfPressMachine()
        {
            idname = "Calf Press Machine";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class PullUpBar : AEquipment
    {
        public PullUpBar()
        {
            idname = "Pull Up Bar";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class  Treadmill : AEquipment
    {
        public Treadmill()
        {
            idname = "Treadmill";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class RowingMachine : AEquipment
    {
        public RowingMachine()
        {
            idname = "Rowing Machine";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class  Stairs : AEquipment
    {
        public Stairs()
        {
            idname = "Stairs";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class  Elliptical : AEquipment
    {
        public Elliptical()
        {
            idname = "Elliptical";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }
}
