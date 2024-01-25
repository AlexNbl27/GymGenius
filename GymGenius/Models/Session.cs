using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using GymGenius.Controllers;

namespace GymGenius.Models
{
    public class Session
    {
        protected List<AExercise> exercises;
        protected float totalDuration;
        protected bool isAtHome;
        protected TimeController restTime;

        public Session(List<AExercise> _exercises)
        {
            exercises = _exercises;
            totalDuration = 0;
            isAtHome = false;
            //restTime = new TimeController();
        }
    }
}
