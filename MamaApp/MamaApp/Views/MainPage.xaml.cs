using MamaApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MamaApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MamaApp.Views
{
    

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        BaseViewModel viewModel;
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage(BaseViewModel viewModel)
        {
            InitializeComponent();

            this.viewModel = viewModel;

            BindingContext = new BaseViewModel();

            MasterBehavior = MasterBehavior.Popover;

            try
            {
                MenuPages.Add((int)MenuItemType.Meniu, (NavigationPage)Detail);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

        }

        public BaseViewModel ViewModel {
            get {
                return (BaseViewModel)BindingContext;
            }
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Meniu:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.Muzică:
                        MenuPages.Add(id, new NavigationPage(new MuzicăPage()));
                        break;
                    default: await DisplayAlert("Încă nu e implementat, vă rugăm reveniți", "", "Ok", "Anulează");
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged -= Current_ConnectivityChanged;
        }

        private async void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (this.viewModel.HasNetworkAccess is false)
            {
                try
                {
                    await DisplayAlert("Vezi că nu ai internet", "Verifică să ai access la internet", "Ok",
                        "Sună Alex");

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}