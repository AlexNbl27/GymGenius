namespace GymGenius.Models
{
    public abstract class ASessionState
    {
        public event Action<int> CurrentExerciseIndexChanged;

        protected void RaiseCurrentExerciseIndexChanged(int newIndex)
        {
            CurrentExerciseIndexChanged?.Invoke(newIndex);
        }

        public abstract void OnEnter();
        public abstract void OnExit();
    }


    public class ExerciseState : ASessionState
    {
        private readonly AExercise currentExercise;
        private readonly int currentExerciseIndex;

        public ExerciseState(AExercise _currentExercise, int _currentExerciseIndex)
        {
            currentExercise = _currentExercise;
            currentExerciseIndex = _currentExerciseIndex;
        }

        public override void OnEnter()
        {
        }

        public override void OnExit()
        {
            RaiseCurrentExerciseIndexChanged(currentExerciseIndex + 1);
        }

    }

    internal class RestState : ASessionState
    {

        public override void OnEnter()
        {
        }

        public override void OnExit()
        {
        }
    }
}
