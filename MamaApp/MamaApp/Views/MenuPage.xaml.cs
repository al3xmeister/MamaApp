using MamaApp.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MamaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);


            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;
                ListViewMenu.SelectedItem = null;
                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
            };
        }
    }
}