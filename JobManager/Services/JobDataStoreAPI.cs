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
        private static string StudentNumber => "A00237487";
        private static string API => $"https://jobmanagerdevapi.azurewebsites.net/{StudentNumber}";

        public async Task AddJob(Job job)
        {
            var service = DependencyService.Get<IWebClientService>();
            var jsonString = await service.PostAsync($"{API}/Jobs", JsonConvert.SerializeObject(job), "application/json");
            if (jsonString != null)
            {
                var newJob = JsonConvert.DeserializeObject<Job>(jsonString);
            }
        }

        public async Task DeleteJob(int jobId)
        {
            
        }

        public async Task<Job> GetJob(int jobId)
        {
            var service = DependencyService.Get<IWebClientService>();
            var jsonString = await service.GetAsync($"{API}/Jobs/{jobId}");
            var job = JsonConvert.DeserializeObject<Job>(jsonString);
            return job;
        }

        public async Task<IEnumerable<Job>> GetJobs()
        {
            var service = DependencyService.Get<IWebClientService>();
            var jsonString = await service.GetAsync($"{API}/Jobs");
            var jobs = JsonConvert.DeserializeObject<List<Job>>(jsonString);
            return jobs;
        }

        public async Task UpdateJob(Job job)
        {
            var service = DependencyService.Get<IWebClientService>();
            await service.PutAsync($"{API}/Jobs/{job.Id}", JsonConvert.SerializeObject(job), "application/json");
        }
    }
}
