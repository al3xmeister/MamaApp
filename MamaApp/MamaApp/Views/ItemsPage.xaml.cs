﻿using System;
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
using Xamarin.Essentials;

namespace MamaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        readonly ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            hamburgerButton.ImageSource = (FileImageSource)ImageSource.FromFile("ic_menu_white_24dp.png");
            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;

            BindingContext = viewModel = new ItemsViewModel();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (!viewModel.HasNetworkAccess)
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

        private void HamburgerButton_Clicked(object sender, EventArgs e)
        {
            navigationDrawer.ToggleDrawer();
            // Use default vibration length
           // Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(0.5);
            Vibration.Vibrate(duration);
        }

  }
}