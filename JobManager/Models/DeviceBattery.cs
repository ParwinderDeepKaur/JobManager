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
        public string State { get; set;}
        public string Source { get; set;}
    }
}