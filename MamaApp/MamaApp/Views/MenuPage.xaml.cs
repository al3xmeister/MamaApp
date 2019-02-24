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

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Meniu, Title="" },
                new HomeMenuItem {Id = MenuItemType.Muzică, Title="" },
                new HomeMenuItem {Id = MenuItemType.Știri, Title="" },
                new HomeMenuItem {Id = MenuItemType.Horoscop, Title="" },
                new HomeMenuItem {Id = MenuItemType.Whatsapp, Title="" },
                new HomeMenuItem {Id = MenuItemType.Whatsapp, Title="" },
                new HomeMenuItem {Id = MenuItemType.Whatsapp, Title="" },
                new HomeMenuItem {Id = MenuItemType.Mesaje, Title="" },
                new HomeMenuItem {Id = MenuItemType.Telefon, Title="" },
                new HomeMenuItem {Id = MenuItemType.Țintar, Title="" },
                new HomeMenuItem {Id = MenuItemType.Silențios, Title="" },
                new HomeMenuItem {Id = MenuItemType.Conexiune, Title="" }
            };

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