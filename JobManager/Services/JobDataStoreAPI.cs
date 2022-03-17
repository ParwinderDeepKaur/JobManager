using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JobManager.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace JobManager.Services
{
    class JobDataStoreAPI : IJobDataStore<Job>
    {
        public Task AddJob(Job job)
        {
            throw new NotImplementedException();
        }

        public Task DeleteJob(Job job)
        {
            throw new NotImplementedException();
        }

        public async Task<Job> GetJob(int jobId)
        {
            var service = DependencyService.Get<IWebClientService>();
            var jsonString = await service.GetString("https://jobmanagerdevapi.azurewebsites.net/A00237487/Jobs/" + jobId);
            var job = JsonConvert.DeserializeObject<Job>(jsonString);
            return job;
        }

        public async Task<IEnumerable<Job>> GetJobs()
        {
            var service = DependencyService.Get<IWebClientService>();
            var jsonString = await service.GetString("https://jobmanagerdevapi.azurewebsites.net/A00237487/Jobs");
            var job = JsonConvert.DeserializeObject<List<Job>>(jsonString);
            return job;
        }

        public Task UpdateJob(Job job)
        {
            throw new NotImplementedException();
        }
    }
}
