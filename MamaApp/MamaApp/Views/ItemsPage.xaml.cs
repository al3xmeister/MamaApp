using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MamaApp.Models;
using MamaApp.Views;
using MamaApp.ViewModels;

namespace MamaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;

            BindingContext = viewModel = new ItemsViewModel();
          //  NavigationPage.SetHasNavigationBar(this, false);   
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (viewModel.HasNetworkAccess is false)
            {
                try
                {
                    var alert = await DisplayAlert("Vezi că nu ai internet", "Verifică să ai access la internet", "Ok",
                        "Sună Alex");

                    if (!alert)
                    {
                        Device.OpenUri(new Uri("tel:+447534848580"));
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged -= Current_ConnectivityChanged;
        }

        private void HamburgerMenuImage_OnTapped(object sender, EventArgs e)
        {
            this.Drawer.IsOpen = !this.Drawer.IsOpen;
        }


    }
}