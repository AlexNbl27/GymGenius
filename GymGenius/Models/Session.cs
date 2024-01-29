using GymGenius.Controllers;

namespace GymGenius.Models
{
    public class Session
    {
        public List<AExercise> exercises;
        public float totalDuration;
        public bool isAtHome;
        public TimeController restTime;

        public Session(List<AExercise> _exercises)
        {
            exercises = _exercises;
            totalDuration = 0;
            isAtHome = false;
            //restTime = new TimeController();
        }
    }
}
