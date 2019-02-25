using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MamaApp.Models;
using MamaApp.Utility;
using MamaApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MamaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ȘtiriPage : ContentPage
    {

        public ȘtiriPage(ȘtiriPageViewModel viewModel)
        {
            Model = viewModel;
            InitializeComponent();

            BindingContext = viewModel = new ȘtiriPageViewModel();

            var viewModelNews = this.Model.Articles;
            if (viewModelNews != null)
                BookingList.ItemsSource = viewModelNews;
        }

        public ȘtiriPageViewModel Model {
            get { return (ȘtiriPageViewModel)BindingContext; }
            set { BindingContext = value; }
        }
      

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void OnNewsItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {
           // throw new NotImplementedException();
        }
    }
}
