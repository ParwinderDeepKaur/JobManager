using System;
using System.Threading.Tasks;
using JobManager.Services;
using MvvmHelpers.Commands;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JobManager.ViewModels
{
    class WelcomeViewModel :JobManagerBase
    {

        private  double level;

        public double Level
        {
            get => level;
            set => SetProperty(ref level, value);

        }
        
        public string state;
        public string State
        {
            get => state;
            set => SetProperty(ref state, value);
        }
        
        public string source;
        public string Source
        {
            get => source;
            set => SetProperty(ref source, value);
        }
    public WelcomeViewModel() 
        {
            Title = "Welcome";
            GetBatteryStatus();
        }

        void GetBatteryStatus()
        {
            var service = DependencyService.Get<IDeviceBatteryService>();
            var deviceBattery = service.GetBattery();
            Level = deviceBattery.Level;
            Source = deviceBattery.Source;
            State = deviceBattery.State;
        }
    }
}
