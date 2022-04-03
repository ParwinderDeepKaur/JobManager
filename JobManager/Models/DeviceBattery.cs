using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace JobManager.Models
{
    public class DeviceBattery 
    {
        public double Level { get; set; }
        public States State { get; set;}
        public Sources Source { get; set;}

        public enum States
        {
            Charging,
            Full,
            Discharging,
            NotCharging,
            NotPresent,
            Unkown
        }

        public enum Sources
        {
            Battery,
            AC,
            USB,
            Wireless,
            Unknown
        }
    }
}