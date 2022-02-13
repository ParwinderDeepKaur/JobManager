using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JobManager.Models;

namespace JobManager.Services
{
    class JobDataStoreLocalJson : IJobDataStore<Job>
    {
        public async Task AddJob(Job job)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteJob(Job job)
        {
            throw new NotImplementedException();
        }

        public async Task<Job> GetJob(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Job>> GetJobs()
        {
            var jobs = new List<Job>(){
                new Job{Id = 1, Name = "job A local json file", Description = "this is a job A." },
                new Job{Id = 1, Name = "job B local json file", Description = "this is a job B." },
                new Job{Id = 1, Name = "job C local json file", Description = "this is a job C." },
                new Job{Id = 1, Name = "job D local json file", Description = "this is a job D." }
            };
            //throw new NotImplementedException();
            return jobs;
        }

        public async Task UpdateJob(Job job)
        {
            throw new NotImplementedException();
        }
    }
}
