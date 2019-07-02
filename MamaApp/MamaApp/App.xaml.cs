﻿using System;
using MamaApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MamaApp.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MamaApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            MainPage = new ItemsPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("d8f823b0-9497-4973-8d4b-4c863b547c7e",
                   typeof(Analytics), typeof(Crashes));
            AppCenter.Start("d8f823b0-9497-4973-8d4b-4c863b547c7e",
                               typeof(Analytics), typeof(Crashes));
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
