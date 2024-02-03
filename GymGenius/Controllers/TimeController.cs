namespace GymGenius.Controllers
{
    public class TimeController
    {
        private float hour;
        private float minute;
        private float second;

        public TimeController(DateTime time)
        {
            hour = time.Hour;
            minute = time.Minute;
            second = time.Second;
        }

        public TimeController(float hour, float minute, float second)
        {
            if (second >= 60)
            {
                minute += (int)second / 60;
                second = second % 60;
            }
            if (minute >= 60)
            {
                hour += (int)minute / 60;
                minute = minute % 60;
            }
            if (hour >= 24)
            {
                hour = hour % 24;
            }
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public TimeController(double seconds)
        {
            hour = (int)seconds / 3600;
            minute = ((int)seconds % 3600) / 60;
            second = (float)(seconds % 60);
        }


        public void setTime(float hour, float minute, float second)
        {
            if (second >= 60)
            {
                minute += (int)second / 60;
                second = second % 60;
            }
            if (minute >= 60)
            {
                hour += (int)minute / 60;
                minute = minute % 60;
            }
            if (hour >= 24)
            {
                hour = hour % 24;
            }
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public void setTime(string time)
        {
            string[] timeArray = time.Split(':');
            hour = float.Parse(timeArray[0]);
            minute = float.Parse(timeArray[1]);
            second = float.Parse(timeArray[2]);
        }

        public double getDurationInSecond()
        {
            return (hour * 3600) + (minute * 60) + second;
        }

        public string getFormatDuration()
        {
            string _second = second < 10 ? "0" + second : second.ToString();
            string _minute = minute < 10 ? "0" + minute : minute.ToString();

            return _minute + ":" + _second;
        }
    }
}
