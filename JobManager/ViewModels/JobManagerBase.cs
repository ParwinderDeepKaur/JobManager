using System;
using System.Collections.Generic;
using System.Text;
using JobManager.Models;
using JobManager.Services;
using MvvmHelpers;
using Xamarin.Forms;

namespace JobManager.ViewModels
{
    class JobManagerBase : BaseViewModel
    {
        public IJobDataStore<Job> JobDataStore => DependencyService.Get<IJobDataStore<Job>>();
    }
}
