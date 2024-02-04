using GymGenius.Models;

namespace GymGenius.ModelView
{
    public class ExercisesPageLogic
    {

        private readonly List<AExercise> allExercises =
        [
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
        ];
        public List<AExercise> GetAllExercises()
        {
            return allExercises;
        }

        public List<AExercise> GetFilteredExercises(bool legs, bool arms, bool back, bool shoulders, bool trunk, bool cardio, bool muscular, int difficulty = 99)
        {
            List<AExercise> filteredExercises = [];
            if (legs)
            {
                filteredExercises.AddRange(GetLegsExercises());
            }
            if (arms)
            {
                filteredExercises.AddRange(GetArmsExercises());
            }
            if (back)
            {
                filteredExercises.AddRange(GetBackExercises());
            }
            if (shoulders)
            {
                filteredExercises.AddRange(GetShouldersExercises());
            }
            if (trunk)
            {
                filteredExercises.AddRange(GetTrunkExercises());
            }

            // Remove duplicates
            filteredExercises = filteredExercises.Distinct().ToList();
            // If no muscles are selected, we return all exercises
            filteredExercises = filteredExercises.Count == 0 ? allExercises : filteredExercises;

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

            // Remove duplicates
            filteredExercises = filteredExercises.Distinct().ToList();

            return filteredExercises;
        }

        private List<AExercise> GetLegsExercises()
        {
            List<AExercise> legsExercises = [];
            foreach (AExercise exercise in allExercises)
            {
                foreach (AMuscle muscle in exercise.Tags.Muscles)
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
            List<AExercise> armsExercises = [];
            foreach (AExercise exercise in allExercises)
            {
                foreach (AMuscle muscle in exercise.Tags.Muscles)
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
            List<AExercise> chestExercises = [];
            foreach (AExercise exercise in allExercises)
            {
                foreach (AMuscle muscle in exercise.Tags.Muscles)
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
            List<AExercise> shouldersExercises = [];
            foreach (AExercise exercise in allExercises)
            {
                foreach (AMuscle muscle in exercise.Tags.Muscles)
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
            List<AExercise> trunkExercises = [];
            foreach (AExercise exercise in allExercises)
            {
                foreach (AMuscle muscle in exercise.Tags.Muscles)
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
            List<AExercise> cardioExercises = [];

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
            List<AExercise> muscularExercises = [];

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
            List<AExercise> filteredByDifficultyExercises = [];

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
