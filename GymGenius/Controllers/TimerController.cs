using GymGenius.ModelView;
using System.Windows;
using System.Windows.Threading;

namespace GymGenius.Controllers
{
    public class TimerController
    {
        private Window window;
        private ITimerHandler timerHandler;
        private DispatcherTimer timer;
        public TimeSpan currentTimeElapsed;

        public TimerController(ITimerHandler timerHandler)
        {
            this.timerHandler = timerHandler;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(1);
            this.timer.Tick += Timer_Tick;
            this.timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.currentTimeElapsed = this.currentTimeElapsed.Add(TimeSpan.FromSeconds(1));
            timerHandler.Timer_Tick(sender, e);
        }

        public void Start()
        {
            this.timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void Reset()
        {
            timer.Stop();
            this.currentTimeElapsed = TimeSpan.Zero;
        }
    }
}
