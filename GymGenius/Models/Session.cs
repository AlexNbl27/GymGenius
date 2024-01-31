using GymGenius.Controllers;

namespace GymGenius.Models
{
    public class Session
    {
        public List<AExercise> exercises;
        public float totalDuration;
        public bool isAtHome;
        public TimeController restTime;

        public Session(TimeController _restTime)
        {
            this.exercises = new List<AExercise>();
            this.totalDuration = 0;
            this.isAtHome = false;
            this.restTime = _restTime;
        }

        public Session(TimeController _restTime, List<AExercise> _exercises)
        {
            this.exercises = _exercises;
            this.totalDuration = 0;
            this.isAtHome = false;
            this.restTime = new TimeController(0, 0, 30);
        }
    }
}
