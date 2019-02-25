using MamaApp.Models;
using MamaApp.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MamaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ȘtiriPage : ContentPage
    {

        public ȘtiriPage(ȘtiriPageViewModel viewModel)
        {
            IsBusy = true;
            Model = viewModel;
            InitializeComponent();

            InitializeNews();

            IsBusy = false;
        }

        private async void InitializeNews()
        {
            await Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    IsBusy = true;
                });
            });

            await Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ȘtiriPageViewModel viewModel;
                    BindingContext = viewModel = new ȘtiriPageViewModel();
                });
            });

            await Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    IsBusy = true;
                });
            });
        }

        public ȘtiriPageViewModel Model {
            get { return (ȘtiriPageViewModel)BindingContext; }
            set { BindingContext = value; }
        }


        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
            {
                IsBusy = true;
            });
            });

            if (e.Item == null)
                return;

            ((ListView)sender).SelectedItem = null;

            await Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
               {
                   var item = (Article)e.Item;
                   var url = item.url;

                   Device.OpenUri(new Uri(url));
               });
            });
            await Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    IsBusy = false;
                });
            });
        }
    }
}
