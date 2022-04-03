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
            double level = Battery.ChargeLevel;
            string state = "", source = "";

            switch (Battery.State)
            {
                case BatteryState.Charging:
                    state = "Charging";
                    break;
                case BatteryState.Full:
                    state = "Full";
                    break;
                case BatteryState.Discharging:
                case BatteryState.NotCharging:
                    state = "Not Charging";
                    break;
                case BatteryState.NotPresent:
                    state = "Not Present";
                    break;
                case BatteryState.Unknown:
                    state = "Unknown";
                    break;
            }


            switch (Battery.PowerSource)
            {
                case BatteryPowerSource.Battery:
                    source = "Battery";
                    break;
                case BatteryPowerSource.AC:
                    source = "AC";
                    break;
                case BatteryPowerSource.Usb:
                    source = "USB";
                    break;
                case BatteryPowerSource.Wireless:
                    source = "Wireless";
                    break;
                case BatteryPowerSource.Unknown:
                    source = "Unknown";
                    break;
            }

            DeviceBattery batteryObj = new DeviceBattery();
            batteryObj.Level = level;
            batteryObj.State = state;
            batteryObj.Source = source;
            Console.WriteLine("Battery : " + level + " " + state + " " + source);
            return batteryObj;
        }
    }
}