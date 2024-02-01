﻿using GymGenius.Controller;
using GymGenius.Controllers;
using GymGenius.Models;

namespace GymGenius.Models
{
    public abstract class AExercise
    {
        protected string idname;
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Level { get; protected set; }
        public TimeController Duration { get; protected set; } = new TimeController(new DateTime());

        public AExerciseType Type = new Muscular();
        public List<AEquipment> Equipments { get; protected set; } = new List<AEquipment>();

        public struct TagsStruct
        {
            public List<AMuscles> Muscles;
            public bool isAtHome;
        }


        public TagsStruct Tags = new TagsStruct();
    }

    public interface ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }
    }

    public class Dips : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public Dips()
        {
            idname = "Dips";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:00:03");
            Equipments.Add(new DoubleBars());
            Equipments.Add(new MachineDips());
            Type = new Muscular();
            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Triceps());
            Tags.Muscles.Add(new Deltoids());
            Tags.Muscles.Add(new RotatorCuff());
            Tags.Muscles.Add(new Pectorals());
            Tags.Muscles.Add(new Trapezius());
            Tags.Muscles.Add(new Rhomboids());
            Tags.Muscles.Add(new Abdominals());
            Tags.isAtHome = true;
        }
    }

    public class BenchPress : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public BenchPress()
        {
            idname = "BenchPress";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 2;
            Duration.setTime("00:00:03");
            Equipments.Add(new WeightBench());
            Equipments.Add(new Dumbbells());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Pectorals());
            Tags.Muscles.Add(new Biceps());
            Tags.isAtHome = false;
        }
    }

    public class InclinedBenchPress : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public InclinedBenchPress()
        {
            idname = "InclinedBenchPress";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 2;
            Duration.setTime("00:00:03");
            Equipments.Add(new WeightBench());
            Equipments.Add(new Dumbbells());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Pectorals());
            Tags.Muscles.Add(new Biceps());
            Tags.Muscles.Add(new Triceps());
            Tags.Muscles.Add(new Deltoids());
            Tags.isAtHome = false;
        }
    }

    public class ForeheadBar : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public ForeheadBar()
        {
            idname = "ForeheadBar";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 2;
            Duration.setTime("00:00:03");
            Equipments.Add(new CurlBar());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Triceps());
            Tags.Muscles.Add(new Deltoids());
            Tags.Muscles.Add(new Pectorals());
            Tags.isAtHome = false;
        }
    }

    public class PulleyTricepsExtensions : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public PulleyTricepsExtensions()
        {
            idname = "PulleyTricepsExtensions";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:00:03");
            Equipments.Add(new HighPulley());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Triceps());
            Tags.Muscles.Add(new Deltoids());
            Tags.isAtHome = false;
        }
    }

    public class CableMiddleFly : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public CableMiddleFly()
        {
            idname = "CableMiddleFly";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:00:03");
            Equipments.Add(new HighPulley());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Pectorals());
            Tags.Muscles.Add(new Deltoids());
            Tags.isAtHome = false;
        }
    }

    public class Crunch : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public Crunch()
        {
            idname = "Crunch";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 1;
            Duration.setTime("00:00:03");
            Equipments.Add(new FitnessMat());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Abdominals());
            Tags.isAtHome = true;
        }
    }

    public class SideElevation : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public SideElevation()
        {
            idname = "SideElevation";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:00:03");
            Equipments.Add(new FitnessMat());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Obliques());
            Tags.Muscles.Add(new Deltoids());
            Tags.Muscles.Add(new Trapezius());
            Tags.isAtHome = true;
        }
    }

    public class FrontalElevation : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public FrontalElevation()
        {
            idname = "FrontalElevation";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:00:03");
            Equipments.Add(new Dumbbells());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Deltoids());
            Tags.Muscles.Add(new Trapezius());
            Tags.Muscles.Add(new Biceps());
            Tags.isAtHome = false;
        }
    }

    public class BirdElevation : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public BirdElevation()
        {
            idname = "BirdElevation";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:00:03");
            Equipments.Add(new Dumbbells());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Deltoids());
            Tags.Muscles.Add(new Trapezius());
            Tags.Muscles.Add(new Rhomboids());
            Tags.isAtHome = false;
        }
    }

    public class MilitaryPress : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public MilitaryPress()
        {
            idname = "MilitaryPress";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 4;
            Duration.setTime("00:00:03");
            Equipments.Add(new Dumbbells());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Deltoids());
            Tags.Muscles.Add(new Trapezius());
            Tags.Muscles.Add(new Triceps());
            Tags.isAtHome = false;
        }
    }

    public class InvertedPecDeck : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public InvertedPecDeck()
        {
            idname = "InvertedPecDeck";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 2;
            Duration.setTime("00:00:03");
            Equipments.Add(new MachinePecDeck());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Deltoids());
            Tags.Muscles.Add(new Rhomboids());
            Tags.Muscles.Add(new Trapezius());
            Tags.Muscles.Add(new Triceps());
            Tags.isAtHome = false;
        }
    }

    public class FacePull : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public FacePull()
        {
            idname = "FacePull";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:00:03");
            Equipments.Add(new Pulley());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Deltoids());
            Tags.Muscles.Add(new Trapezius());
            Tags.Muscles.Add(new Triceps());
            Tags.isAtHome = false;
        }
    }

    public class HorizontalDraft : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public HorizontalDraft()
        {
            idname = "HorizontalDraft";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:00:03");
            Equipments.Add(new LowPulley());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new LargeDorsals());
            Tags.Muscles.Add(new Deltoids());
            Tags.Muscles.Add(new Biceps());
            Tags.isAtHome = true;
        }
    }

    public class Deadlift : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public Deadlift()
        {
            idname = "Deadlift";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 2;
            Duration.setTime("00:00:03");
            Equipments.Add(new WeightBar());
            Equipments.Add(new WeightDiscus());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new LargeDorsals());
            Tags.Muscles.Add(new Quadriceps());
            Tags.Muscles.Add(new Biceps());
            Tags.Muscles.Add(new Hamstrings());
            Tags.Muscles.Add(new Glutes());
            Tags.isAtHome = false;
        }
    }

    public class BicepsCurl : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public BicepsCurl()
        {
            idname = "BicepsCurl";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 1;
            Duration.setTime("00:00:02");
            Equipments.Add(new CurlBar());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Biceps());
            Tags.isAtHome = false;
        }
    }

    public class CurlRotation : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public CurlRotation()
        {
            idname = "CurlRotation";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 1;
            Duration.setTime("00:00:03");
            Equipments.Add(new Dumbbells());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Biceps());
            Tags.isAtHome = false;
        }
    }

    public class PulleyCurl : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public PulleyCurl()
        {
            idname = "PulleyCurl";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:00:03");
            Equipments.Add(new LowPulley());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Biceps());
            Tags.isAtHome = false;
        }
    }

    public class Squat : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public Squat()
        {
            idname = "Squat";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:00:03");
            Equipments.Add(new Weights());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Quadriceps());
            Tags.Muscles.Add(new Hamstrings());
            Tags.Muscles.Add(new Glutes());
            Tags.isAtHome = true;
        }
    }

    public class LegPress : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public LegPress()
        {
            idname = "LegPress";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:00:03");
            Equipments.Add(new Press());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Quadriceps());
            Tags.Muscles.Add(new Hamstrings());
            Tags.Muscles.Add(new Glutes());
            Tags.isAtHome = false;
        }
    }

    public class Slots : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public Slots()
        {
            idname = "Slots";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:00:03");
            Equipments.Add(new Weights());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Quadriceps());
            Tags.Muscles.Add(new Glutes());
            Tags.Muscles.Add(new Hamstrings());
            Tags.isAtHome = true;
        }
    }

    public class LegsExtensions : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public LegsExtensions()
        {
            idname = "LegsExtensions";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 2;
            Duration.setTime("00:00:03");
            Equipments.Add(new MachineLegExtension());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Quadriceps());
            Tags.isAtHome = false;
        }
    }

    public class LegsFlexions : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public LegsFlexions()
        {
            idname = "LegsFlexions";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 2;
            Duration.setTime("00:00:03");
            Equipments.Add(new MachineLegCurl());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Hamstrings());
            Tags.isAtHome = false;
        }
    }


    public class CalfPress : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public CalfPress()
        {
            idname = "CalfPress";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 1;
            Duration.setTime("00:00:03");
            Equipments.Add(new CalfPressMachine());
            Type = new Muscular();
            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Calves());
            Tags.isAtHome = false;
        }
    }


    public class PushUps : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public PushUps()
        {
            idname = "PushUps";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:00:03");
            Equipments.Add(new FitnessMat());
            Type = new Muscular();
            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Abdominals());
            Tags.Muscles.Add(new Pectorals());
            Tags.Muscles.Add(new Deltoids());
            Tags.Muscles.Add(new Trapezius());
            Tags.Muscles.Add(new Biceps());
            Tags.Muscles.Add(new Triceps());
            Tags.Muscles.Add(new Quadriceps());
            Tags.Muscles.Add(new LargeDorsals());
            Tags.Muscles.Add(new SmallDorsals());
            Tags.isAtHome = true;
        }
    }

    public class PullUps : AExercise, ISerie
    {
        public int NbRepetitions { get; set; }
        public TimeController DodoTime { get; set; }

        public PullUps()
        {
            idname = "PullUps";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 4;
            Duration.setTime("00:00:05");
            Equipments.Add(new PullUpBar());
            Type = new Muscular();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Abdominals());
            Tags.Muscles.Add(new Pectorals());
            Tags.Muscles.Add(new Deltoids());
            Tags.Muscles.Add(new Trapezius());
                Tags.Muscles.Add(new Biceps());
            Tags.Muscles.Add(new Triceps());
            Tags.Muscles.Add(new Quadriceps());
            Tags.Muscles.Add(new LargeDorsals());
            Tags.Muscles.Add(new SmallDorsals());
            Tags.isAtHome = false;
        }
    }

    public class Treadmill : AExercise
    {
        public Treadmill()
        {
            idname = "Treadmill";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 2;
            Duration.setTime("00:15:00");
            Equipments.Add(new TreadmillMachine());
            Type = new Cardio();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Quadriceps());
            Tags.Muscles.Add(new Glutes());
            Tags.Muscles.Add(new Hamstrings());
            Tags.Muscles.Add(new LargeDorsals());
            Tags.isAtHome = false;
        }
    }

    public class Rowing : AExercise
    {
        public Rowing()
        {
            idname = "Rowing";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:15:00");
            Equipments.Add(new RowingMachine());
            Type = new Cardio();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Quadriceps());
            Tags.Muscles.Add(new Glutes());
            Tags.Muscles.Add(new Hamstrings());
            Tags.isAtHome = false;
        }
    }

    public class Stairs : AExercise
    {
        public Stairs()
        {
            idname = "Stairs";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:10:00");
            Equipments.Add(new StairsMachine());
            Type = new Cardio();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Quadriceps());
            Tags.Muscles.Add(new Glutes());
            Tags.Muscles.Add(new Hamstrings());
            Tags.isAtHome = true;
        }
    }

    public class Elliptical : AExercise
    {
        public Elliptical()
        {
            idname = "ElipticalBike";
            Name = TranslateUtils.Translate(idname, "Name");
            Description = TranslateUtils.Translate(idname, "Description");
            Level = 3;
            Duration.setTime("00:15:00");
            Equipments.Add(new EllipticalMachine());
            Type = new Cardio();

            Tags.Muscles = new List<AMuscles>();
            Tags.Muscles.Add(new Quadriceps());
            Tags.Muscles.Add(new Hamstrings());
            Tags.isAtHome = false;
        }
    }
}
