using System;
using MamaApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MamaApp.Views;

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
