using System.Windows.Threading;

namespace GymGenius.Controllers
{
    public class TimerController
    {
        private readonly ITimerHandler timerHandler;
        private DispatcherTimer timer;
        public TimeSpan currentTimeElapsed;

        public TimerController(ITimerHandler timerHandler)
        {
            this.timerHandler = timerHandler;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentTimeElapsed = currentTimeElapsed.Add(TimeSpan.FromSeconds(1));
            timerHandler.Timer_Tick(sender, e);
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void Reset()
        {
            timer.Stop();
            currentTimeElapsed = TimeSpan.Zero;
        }
    }
}
