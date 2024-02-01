namespace GymGenius.Controllers
{
    public class TimeController
    {
        float hour;
        float minute;
        float second;

        public TimeController(DateTime time)
        {
            this.hour = time.Hour;
            this.minute = time.Minute;
            this.second = time.Second;
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
            this.hour = float.Parse(timeArray[0]);
            this.minute = float.Parse(timeArray[1]);
            this.second = float.Parse(timeArray[2]);
        }

        public double getDurationInSecond()
        {
            return (this.hour * 3600) + (this.minute * 60) + this.second;
        }
    }
}
