using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross.Forms.Platform;
using Xamarin.Forms;

namespace MvxForms.UI
{
    public partial class App : MvxFormsApplication
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MvxForms.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
