using GymGenius.Controller;

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
            idname = "FitnessMat";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class DoublesBars : AEquipment
    {
        public DoublesBars()
        {
            idname = "DoublesBars";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class MachineDips : AEquipment
    {
        public MachineDips()
        {
            idname = "MachineDips";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class WeightBench : AEquipment
    {
        public WeightBench()
        {
            idname = "WeightBench";
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
            idname = "CurlBar";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class HighPulley : AEquipment
    {
        public HighPulley()
        {
            idname = "HighPulley";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class LowPulley : AEquipment
    {
        public LowPulley()
        {
            idname = "LowPulley";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class DoublePulley : AEquipment
    {
        public DoublePulley()
        {
            idname = "DoublePulley";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class MachinePecDeck : AEquipment
    {
        public MachinePecDeck()
        {
            idname = "MachinePecDeck";
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
            idname = "WeightBar";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class WeightDiscus : AEquipment
    {
        public WeightDiscus()
        {
            idname = "WeightDiscus";
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
            idname = "MachineLegExtension";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class MachineLegCurl : AEquipment
    {
        public MachineLegCurl()
        {
            idname = "MachineLegCurl";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class CalfPressMachine : AEquipment
    {
        public CalfPressMachine()
        {
            idname = "CalfPressMachine";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class PullUpBar : AEquipment
    {
        public PullUpBar()
        {
            idname = "PullUpBar";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class TreadmillMachine : AEquipment
    {
        public TreadmillMachine()
        {
            idname = "TreadmillMachine";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class RowingMachine : AEquipment
    {
        public RowingMachine()
        {
            idname = "RowingMachine";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class StairsMachine : AEquipment
    {
        public StairsMachine()
        {
            idname = "StairsMachine";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }

    public class EllipticalMachine : AEquipment
    {
        public EllipticalMachine()
        {
            idname = "EllipticalMachine";
            Name = TranslateUtils.Translate(idname, "Name");
        }
    }
}
