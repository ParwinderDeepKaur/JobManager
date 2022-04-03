using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using JobManager.Models;
using JobManager.Services;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace JobManager.ViewModels
{
    [QueryProperty(nameof(JobId), nameof(JobId))]
    public class JobDetailViewModel : JobManagerBase
    {
        public AsyncCommand SaveCommand { get; }
        public AsyncCommand TakePicture { get; }

        private int jobId;
        public int JobId
        {
            get
            {
                return jobId;
            }
            set
            {
                jobId = value;
                LoadJob(value);
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }


        private ImageSource picture;
        public ImageSource Picture
        {
            get => picture;
            set => SetProperty(ref picture, value);
        }


        public JobDetailViewModel()
        {
            SaveCommand = new AsyncCommand(Save);
            TakePicture = new AsyncCommand(CapturePhoto);

        }

        async Task Save()
        {
            Job job = new Job
            {
                Id = jobId,
                Name = Name,
                Description = Description
            };

            if (jobId == 0)
            {
                //to add new job
                await JobDataStore.AddJob(job);
            }
            else
            {
                // to update an existing job
                await JobDataStore.UpdateJob(job);
            }
            await Shell.Current.GoToAsync("..");
        }

        async Task CapturePhoto()
        {
            var service = DependencyService.Get<IMediaService>();
            var bytes = await service.CapturePhotoAsync();
            Picture = ImageSource.FromStream(() => new MemoryStream(bytes));

            //var blob = DependencyService.Get<IBlobStorageService>();
            //await blob.UploadStreamAsync($"Jobs/Pictures/{JobId}/{Guid.NewGuid()}.png", new MemoryStream(bytes));
        }

        public async void LoadJob(int jobId)
        {
            try
            {
                var job = await JobDataStore.GetJob(jobId);
                Name = job.Name;
                Description = job.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
