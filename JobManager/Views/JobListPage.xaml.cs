using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JobManager.Models;
using JobManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobListPage : ContentPage
    {
        JobListViewModel _viewModel;
        JobManagerBase _JobManagerBase;
        public JobListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new JobListViewModel();
            _JobManagerBase = new JobManagerBase();
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.Refresh();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void deleteRecord(object sender, EventArgs e)
        {
            var btn = sender as Button;

            var data = btn.BindingContext as Job;
            var getId = data.Id;
            await _JobManagerBase.JobDataStore.DeleteJob(data.Id);
             _viewModel.Refresh();
        }
    }
}