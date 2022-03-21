using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JobManager.Models;

namespace JobManager.Services
{
    public interface IJobDataStore<T>
    {
        Task<IEnumerable<Job>> GetJobs();
        Task<Job> GetJob(int id);
        Task AddJob(Job job);
        Task UpdateJob(Job job);
        Task DeleteJob(int jobId);
    }
}
