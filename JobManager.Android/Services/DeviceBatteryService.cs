using Android.App;
using JobManager.Droid.Services;
using JobManager.Models;
using Xamarin.Essentials;
using JobManager.Services;
using Xamarin.Forms;
using System;

[assembly: Dependency(typeof(DeviceBatteryService))]

[assembly: UsesPermission(Android.Manifest.Permission.BatteryStats)]


namespace JobManager.Droid.Services
{
    public class DeviceBatteryService: IDeviceBatteryService
    {
        public DeviceBattery GetBattery()
        {
            var level = Battery.ChargeLevel;
            var state = Battery.State;
            var source = Battery.PowerSource;
            DeviceBattery batteryObj = new DeviceBattery();
            batteryObj.Level = level;
            batteryObj.State = (DeviceBattery.States)state;
            batteryObj.Source = (DeviceBattery.Sources)source;
            Console.WriteLine("Battery : " + level+" "+state+" "+source);

            return batteryObj;
        }
    }
}