using GymGenius.Controllers;

namespace GymGenius.Models
{
    public class Session
    {
        public Dictionary<int, string> recurrenceOptions = new Dictionary<int, string>();

        public List<AExercise> exercises;
        public float totalDuration = 0;
        public bool isAtHome = false;
        public TimeController restTime = new TimeController(0, 0, 30);
        public DateTime? date = null;
        public int recurrenceId = 0;

        public Session()
        {
            CreateReccurenceDict();
            this.exercises = new List<AExercise>();
        }

        public Session(List<AExercise> _exercises)
        {
            CreateReccurenceDict();
            this.exercises = _exercises;
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
