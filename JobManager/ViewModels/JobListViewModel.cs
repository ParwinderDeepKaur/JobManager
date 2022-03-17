using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JobManager.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace JobManager.ViewModels
{
    class JobListViewModel : JobManagerBase
    {
        public ObservableRangeCollection<Job> Jobs { get; set; }    
        public AsyncCommand RefreshCommand { get;  }
        public AsyncCommand<Job> SelectCommand{ get;  }
        public AsyncCommand AddCommand { get; }

        private Job selectedJob;

        public Job SelectedJob {
            get => selectedJob;
            set => SetProperty(ref selectedJob, value);
        }

        public JobListViewModel() {
            Title = "Jobs";
            Jobs = new ObservableRangeCollection<Job>();
            LoadJobs();
            RefreshCommand = new AsyncCommand(Refresh);
            SelectCommand = new AsyncCommand<Job>(Selected);
        }

        async Task Add()
        {
            string route = $"{nameof(Views.JobDetailPage)}";
            await Shell.Current.GoToAsync(route);
        }

        public async Task Selected(Job job) {
            var route = $"{nameof(Views.JobDetailPage)}?JobId={job.Id}";
            await Shell.Current.GoToAsync(route);
        }

        public async Task Refresh() {
            IsBusy = true;
            Jobs.Clear();
            LoadJobs();
            IsBusy = false;
        }

        public async void LoadJobs() {
            IEnumerable<Job> jobs = await JobDataStore.GetJobs();
            Jobs.AddRange(jobs);
        }
    }
}
