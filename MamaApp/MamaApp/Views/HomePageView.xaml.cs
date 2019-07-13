using System;
using System.Diagnostics;
using MamaApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MamaApp.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageView : ContentPage {
        readonly HomePageViewModel viewModel;

        public HomePageView() {
            InitializeComponent();
            hamburgerButton.ImageSource = (FileImageSource)ImageSource.FromFile("ic_menu_white_24dp.png");
            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;

            BindingContext = viewModel = new HomePageViewModel();

          // NavigationPage.SetHasNavigationBar(this, false);
        }


        protected override void OnAppearing() {
            base.OnAppearing();
        }

        private async void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e) {
            if (!viewModel.HasNetworkAccess) {
                try {
                    var alert = await DisplayAlert("Vezi că nu ai internet", "Verifică să ai access la internet", "Ok",
                        "Sună Alex");

                    if (!alert) {
                        Device.OpenUri(new Uri("tel:+447534848580"));
                    }

                } catch (Exception ex) {
                    Debug.WriteLine(ex);
                }
            }
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged -= Current_ConnectivityChanged;
        }

        private void HamburgerButton_Clicked(object sender, EventArgs e) {
            navigationDrawer.ToggleDrawer();
            // Use default vibration length

            // Or use specified time
            var duration = TimeSpan.FromSeconds(0.3);
            Vibration.Vibrate(duration);
        }

    }
}