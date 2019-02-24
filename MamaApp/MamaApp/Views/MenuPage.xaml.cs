using MamaApp.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MamaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Meniu, Title="Meniu" },
                new HomeMenuItem {Id = MenuItemType.Muzică, Title="Muzică" },
                new HomeMenuItem {Id = MenuItemType.Știri, Title="Știri" },
                new HomeMenuItem {Id = MenuItemType.Horoscop, Title="Horoscop" },
                new HomeMenuItem {Id = MenuItemType.Whatsapp, Title="Whatsapp" },
                new HomeMenuItem {Id = MenuItemType.Mesaje, Title="Mesaje" },
                new HomeMenuItem {Id = MenuItemType.Telefon, Title="Telefon" },
                new HomeMenuItem {Id = MenuItemType.Țintar, Title="Țintar" },
                new HomeMenuItem {Id = MenuItemType.Silențios, Title="Silențios" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;
                ListViewMenu.SelectedItem = null;
                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}