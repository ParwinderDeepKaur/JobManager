using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using JobManager.Models;
using Newtonsoft.Json;

namespace JobManager.Services
{
    class JobDataStoreBlobStorageJson : IJobDataStore<Job>
    {
        private readonly BlobServiceClient service = new BlobServiceClient(ConnectionString); 
        private static string ConnectionString => "connectionstring"; // connection string is hidden because it was mentioned in task to hide it for security purpose
        private static string Container => "data";
        private static string FileName => "Jobs.json";


        public async Task WriteFile(List<Job> jobs)
        {
            var jsonString = JsonConvert.SerializeObject(jobs);
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(jsonString);
            writer.Flush();
            stream.Position = 0;
            BlobClient blob = service.GetBlobContainerClient(Container).GetBlobClient(FileName);
            await blob.UploadAsync(stream);
        }

        public async Task<List<Job>> ReadFile()
        {
            BlobClient blob = service.GetBlobContainerClient(Container).GetBlobClient(FileName);
            if (blob.Exists())
            {
                var stream = new MemoryStream();
                await blob.DownloadToAsync(stream);

                stream.Position = 0;
                var jsonString = new StreamReader(stream).ReadToEnd();
                var jobs = JsonConvert.DeserializeObject<List<Job>>(jsonString);
                return jobs;
            }
            else
            {
                var defaultJobs = GetDefaultJobs();
                await WriteFile(defaultJobs);
                return defaultJobs;

            }
        }

        private List<Job> GetDefaultJobs() 
        {
            var jobs = new List<Job>(){
                new Job{Id = 1, Name = "job A Azure Blob file", Description = "this is a job A." },
                new Job{Id = 2, Name = "job B Azure Blob file", Description = "this is a job B." },
                new Job{Id = 3, Name = "job C Azure Blob file", Description = "this is a job C." },
                new Job{Id = 4, Name = "job D Azure Blob file", Description = "this is a job D." }
            };
            return jobs;

        }

        public async Task AddJob(Job job)
        {
            var jobs = await ReadFile();
            jobs.Add(job);
            await WriteFile(jobs);
        }

        public async Task DeleteJob(Job job)
        {
            throw new NotImplementedException();
        }

        public async Task<Job> GetJob(int id)
        {
            var jobs = await ReadFile();
            var job = jobs.Find(p => p.Id == id);
            return job;
        }

        public async Task<IEnumerable<Job>> GetJobs()
        {
            var jobs = await ReadFile();
            return jobs;
        }

        public async Task UpdateJob(Job job)
        {
            var jobs = await ReadFile();
            jobs[jobs.FindIndex(p => p.Id == job.Id)] = job;
            await WriteFile (jobs);
        }
    }
}
