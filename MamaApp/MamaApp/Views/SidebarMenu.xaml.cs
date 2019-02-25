using MamaApp.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MamaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SidebarMenu : ContentView
    {
        public SidebarMenu()
        {
            InitializeComponent();
        }

        public BaseViewModel ViewModel => (BaseViewModel) BindingContext;


        public void OnAnimationStarted(bool isPopAnimation)
        {
            // Put your code here but leaving empty works just fine
        }

        public void OnAnimationFinished(bool isPopAnimation)
        {
            // Put your code here but leaving empty works just fine
        }


        // this needs uncommented
        //public async Task NavigateIfHasNetworkAccess(Page page) {
        //    if (ViewModel.HasNetworkAccess) {
        //        await Navigation.PushAsync(page);
        //    } else {
        //        await PopupNavigation.Instance.PushAsync(new PopupView("Cannot Connect", "Please check your internet connection and try again.", "OK"));
        //    }
        //}

        private async void Muzică_Tapped(object sender, EventArgs e)
        {
            var view = (View) sender;
            view.IsEnabled = false;

            await Navigation.PushModalAsync((new MuzicăPage()));

            view.IsEnabled = true;
        }

        private async void Horoscop_Tapped(object sender, EventArgs e)
        {
            var today = DateTime.Today;

            var day = today.Day;
            var month = today.Month;
            var year = today.Year;

            var uri = new Uri(
                $"https://www.youtube.com/results?search_query=horoscop+berbec+voropchievici+{day}+{month}+{year}");

            await Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread( () =>
                {
                    Device.OpenUri(uri);
                });
            });
        }

        private async void Știri_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ȘtiriPage(new ȘtiriPageViewModel()));
        }

        private async void NotImplementedYet_Tapped(object sender, EventArgs e)
        {
            await Application.Current.MainPage.DisplayAlert("Încă nu e implementat", "Vă rugăm reveniți sau încercați mai târziu",
                "Ok");
        }
    }
}