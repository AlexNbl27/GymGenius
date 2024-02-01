using GymGenius.Controllers;

namespace GymGenius.Models
{
    public class Session
    {
        public Dictionary<int, string> recurrenceOptions = new Dictionary<int, string>();

        public List<AExercise> exercises;
        public float totalDuration;
        public bool isAtHome;
        public TimeController restTime;
        public DateTime? date;
        public int recurrenceId;

        public Session(TimeController _restTime)
        {
            CreateReccurenceDict();
            this.exercises = new List<AExercise>();
            this.totalDuration = 0;
            this.isAtHome = false;
            this.restTime = _restTime;
            this.date = null;
            this.recurrenceId = 0;
        }

        public Session(TimeController _restTime, List<AExercise> _exercises)
        {
            this.exercises = _exercises;
            this.totalDuration = 0;
            this.isAtHome = false;
            this.restTime = _restTime;
            this.date = null;
        }

        private void CreateReccurenceDict()
        {
            recurrenceOptions.Add(0, "No recurrence");
            recurrenceOptions.Add(1, "FREQ=DAILY");
            recurrenceOptions.Add(2, "FREQ=WEEKLY");
            recurrenceOptions.Add(3, "FREQ=MONTHLY");
            recurrenceOptions.Add(4, "FREQ=YEARLY");
        }

        public string GetRecurrenceString()
        {
            // Check if the key exists in the dictionary
            if (this.recurrenceOptions.ContainsKey(this.recurrenceId))
            {
                return this.recurrenceOptions[this.recurrenceId];
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
