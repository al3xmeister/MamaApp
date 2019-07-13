using MamaApp.Models;
using MamaApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MamaApp.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ȘtiriPage : ContentPage {

        private const string url = "https://newsapi.org/v2/top-headlines?country=ro&apiKey=514376a3e0ee44229f62f33a236b69b0";
        private readonly HttpClient _Client = new HttpClient();
        private readonly ȘtiriPageViewModel viewModel;

        public ȘtiriPage() {


            InitializeComponent();
            viewModel = new ȘtiriPageViewModel();
            BindingContext = viewModel;

        }

        protected override async void OnAppearing() {
            viewModel.IsBusy = true;

            var content = await _Client.GetStringAsync(url);

            //We deserialize the JSON data from this line
            var tr = JsonConvert.DeserializeObject<Result>(content);

            var trends = new ObservableCollection<article>(tr.Articles);

            lstView.ItemsSource = trends;

            viewModel.IsBusy = false;
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e) {

            IsBusy = true;
            
            if (e.Item == null)
                return;

            ((ListView)sender).SelectedItem = null;


            var item = (article)e.Item;
            var url = item.url;

            Device.OpenUri(new Uri(url));

            IsBusy = false;


        }
    }
}
