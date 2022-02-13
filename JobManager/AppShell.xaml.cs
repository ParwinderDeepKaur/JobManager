using System;
using System.Collections.Generic;
using JobManager.Views;
using Xamarin.Forms;

namespace JobManager
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(WelcomePage), typeof(WelcomePage));
        }
    }
}
