using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Job> Get()
        {
            return GetDefaultJobs();
        }

        private List<Job> GetDefaultJobs()
        {
            var jobs = new List<Job>(){
                new Job{Id = 1, Name = "job A API", Description = "this is a job A." },
                new Job{Id = 2, Name = "job B API", Description = "this is a job B." },
                new Job{Id = 3, Name = "job C API", Description = "this is a job C." },
                new Job{Id = 4, Name = "job D API", Description = "this is a job D." }
            };
            return jobs;

        }
    }
}
