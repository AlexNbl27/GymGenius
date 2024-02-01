using GymGenius.Models;

namespace GymGenius.ModelView
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
        AExercise currentExercise;
        int currentExerciseIndex;

        public ExerciseState(AExercise _currentExercise, int _currentExerciseIndex)
        {
            this.currentExercise = _currentExercise;
            this.currentExerciseIndex = _currentExerciseIndex;
        }

        public override void OnEnter()
        {
        }

        public override void OnExit()
        {
            RaiseCurrentExerciseIndexChanged(this.currentExerciseIndex + 1);
        }

    }

    class RestState : ASessionState
    {

        public override void OnEnter()
        {
        }

        public override void OnExit()
        {
        }
    }
}
