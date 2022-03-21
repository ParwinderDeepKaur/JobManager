using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JobManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobListPage : ContentPage
    {
        JobListViewModel _viewModel;
        public JobListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new JobListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.Refresh();
        }
    }
}