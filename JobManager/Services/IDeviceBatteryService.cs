using System.Threading.Tasks;
using JobManager.Models;

namespace JobManager.Services
{
    public interface IDeviceBatteryService
    {
        DeviceBattery GetBattery();
    }
}