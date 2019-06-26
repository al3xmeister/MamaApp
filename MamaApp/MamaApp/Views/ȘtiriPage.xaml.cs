using MamaApp.Models;
using MamaApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json.Linq;

namespace MamaApp.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ȘtiriPage : ContentPage {

        private const string url = "https://newsapi.org/v2/top-headlines?country=ro&apiKey=514376a3e0ee44229f62f33a236b69b0";
        private HttpClient _Client = new HttpClient();
        private ObservableCollection<Result> _post;

        public ȘtiriPage(ȘtiriPageViewModel viewModel) {
            IsBusy = true;
            Model = viewModel;
            InitializeComponent();

            InitializeNews();

            IsBusy = false;
        }

        private async void InitializeNews() {

            IsBusy = true;

            ȘtiriPageViewModel viewModel;
            BindingContext = viewModel = new ȘtiriPageViewModel();

            IsBusy = false;
        }

        public ȘtiriPageViewModel Model {
            get { return (ȘtiriPageViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        protected override async void OnAppearing()
        {
            var response = _Client.GetAsync(url).Result;

            var content = await _Client.GetStringAsync(url);

            //We deserialize the JSON data from this line
            var tr = JsonConvert.DeserializeObject<Result>(content);

            var trends = new ObservableCollection<article>(tr.Articles);

            lstView.ItemsSource = trends;


        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e) {
            await Task.Run(() => {
                Device.BeginInvokeOnMainThread(() => {
                    IsBusy = true;
                });
            });

            if (e.Item == null)
                return;

            ((ListView)sender).SelectedItem = null;

            await Task.Run(() => {
                Device.BeginInvokeOnMainThread(() => {
                    var item = (article)e.Item;
                    var url = item.url;

                    Device.OpenUri(new Uri(url));
                });
            });
            await Task.Run(() => {
                Device.BeginInvokeOnMainThread(() => {
                    IsBusy = false;
                });
            });
        }
    }
}
