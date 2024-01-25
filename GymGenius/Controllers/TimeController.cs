﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenius.Controllers
{
    public class TimeController
    {
        float hour;
        float minute;
        float second;

        public TimeController(float hour, float minute, float second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public void setTime(float hour, float minute, float second)
        {
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

        public float getDurationInSecond()
        {
            return (this.hour * 3600) + (this.minute * 60) + this.second;
        }
    }
}