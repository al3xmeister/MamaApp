using MamaApp.Models;
using MamaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MamaApp.Views
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        BaseViewModel viewModel;
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage(BaseViewModel viewModel)
        {
            InitializeComponent();

            this.viewModel = viewModel;

            BindingContext = new BaseViewModel();

       

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
                    default:
                        await DisplayAlert("Încă nu e implementat, vă rugăm reveniți", "", "Ok", "Anulează");

                        try
                        {

                            //this needs extracted into a static utility method
                            if (Navigation.ModalStack.Count > 0)
                            {
                                await Navigation.PopModalAsync();
                            }
                            else
                                await Navigation.PushAsync(new ItemsPage());
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine(e);

                        }

                        break;
                }
            }

            try
            {
                var newPage = MenuPages[id];
                
            }
            catch (Exception x)
            {
                Debug.WriteLine(x);
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
    }
}