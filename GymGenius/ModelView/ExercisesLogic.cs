using GymGenius.Models;

namespace GymGenius.ModelView
{
    public class ExercisesLogic
    {

        private List<AExercise> allExercises = new List<AExercise>
        {
            new PushUps(),
            new PullUps(),
            new Dips(),
            new BenchPress(),
            new InclinedBenchPress(),
            new ForeheadBar(),
            new PulleyTricepsExtensions(),
            new CableMiddleFly(),
            new Crunch(),
            new SideElevation(),
            new FrontalElevation(),
            new BirdElevation(),
            new MilitaryPress(),
            new InvertedPecDeck(),
            new FacePull(),
            new HorizontalDraft(),
            new Deadlift(),
            new BicepsCurl(),
            new CurlRotation(),
            new PulleyCurl(),
            new Squat(),
            new LegPress(),
            new Slots(),
            new LegsExtensions(),
            new LegsExtensions(),
            new CalfPress(),
            new Treadmill(),
            new Rowing(),
            new Stairs(),
            new Elliptical()
        };
        public List<AExercise> GetAllExercises()
        {
            return this.allExercises;
        }

        public List<AExercise> GetFilteredExercises(bool legs, bool arms, bool back, bool shoulders, bool trunk, bool cardio, bool muscular, int difficulty = 99)
        {
            List<AExercise> filteredExercises = new List<AExercise>();
            if (legs)
            {
                filteredExercises.AddRange(this.GetLegsExercises());
            }
            if (arms)
            {
                filteredExercises.AddRange(this.GetArmsExercises());
            }
            if (back)
            {
                filteredExercises.AddRange(this.GetBackExercises());
            }
            if (shoulders)
            {
                filteredExercises.AddRange(this.GetShouldersExercises());
            }
            if (trunk)
            {
                filteredExercises.AddRange(this.GetTrunkExercises());
            }

            // Remove duplicates
            filteredExercises = filteredExercises.Distinct().ToList();


            if (cardio)
            {
                filteredExercises = FilterCardioExercises(filteredExercises);
            }
            if (muscular)
            {
                filteredExercises = FilterMuscularExercises(filteredExercises);
            }
            if (difficulty != 99)
            {
                filteredExercises = FilterExercisesByDifficulty(filteredExercises, difficulty);
            }

            return filteredExercises;
        }

        private List<AExercise> GetLegsExercises()
        {
            List<AExercise> legsExercises = new List<AExercise>();
            foreach (AExercise exercise in this.allExercises)
            {
                foreach (AMuscles muscle in exercise.Tags.Muscles)
                {
                    if (muscle.bodyPart is Legs)
                    {
                        legsExercises.Add(exercise);
                        break;
                    }
                }
            }
            return legsExercises;
        }

        private List<AExercise> GetArmsExercises()
        {
            List<AExercise> armsExercises = new List<AExercise>();
            foreach (AExercise exercise in this.allExercises)
            {
                foreach (AMuscles muscle in exercise.Tags.Muscles)
                {
                    if (muscle.bodyPart is Arms)
                    {
                        armsExercises.Add(exercise);
                        break;
                    }
                }
            }
            return armsExercises;
        }

        private List<AExercise> GetBackExercises()
        {
            List<AExercise> chestExercises = new List<AExercise>();
            foreach (AExercise exercise in this.allExercises)
            {
                foreach (AMuscles muscle in exercise.Tags.Muscles)
                {
                    if (muscle.bodyPart is Back)
                    {
                        chestExercises.Add(exercise);
                        break;
                    }
                }
            }
            return chestExercises;
        }

        private List<AExercise> GetShouldersExercises()
        {
            List<AExercise> shouldersExercises = new List<AExercise>();
            foreach (AExercise exercise in this.allExercises)
            {
                foreach (AMuscles muscle in exercise.Tags.Muscles)
                {
                    if (muscle.bodyPart is Shoulders)
                    {
                        shouldersExercises.Add(exercise);
                        break;
                    }
                }
            }
            return shouldersExercises;
        }

        private List<AExercise> GetTrunkExercises()
        {
            List<AExercise> trunkExercises = new List<AExercise>();
            foreach (AExercise exercise in this.allExercises)
            {
                foreach (AMuscles muscle in exercise.Tags.Muscles)
                {
                    if (muscle.bodyPart is Trunk)
                    {
                        trunkExercises.Add(exercise);
                        break;
                    }
                }
            }
            return trunkExercises;
        }

        private List<AExercise> FilterCardioExercises(List<AExercise> filteredExercises)
        {
            List<AExercise> cardioExercises = new List<AExercise>();

            foreach (AExercise exercise in filteredExercises)
            {
                if (exercise.Type is Cardio)
                {
                    cardioExercises.Add(exercise);
                }
            }

            return cardioExercises;
        }


        private List<AExercise> FilterMuscularExercises(List<AExercise> filteredExercises)
        {
            List<AExercise> muscularExercises = new List<AExercise>();

            foreach (AExercise exercise in filteredExercises)
            {
                if (exercise.Type is Muscular)
                {
                    muscularExercises.Add(exercise);
                }
            }

            return muscularExercises;
        }

        private List<AExercise> FilterExercisesByDifficulty(List<AExercise> filteredExercises, int difficulty)
        {
            List<AExercise> filteredByDifficultyExercises = new List<AExercise>();

            foreach (AExercise exercise in filteredExercises)
            {
                if (exercise.Level <= difficulty)
                {
                    filteredByDifficultyExercises.Add(exercise);
                }
            }

            return filteredByDifficultyExercises;
        }



    }
}
