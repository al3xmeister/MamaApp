using System;
using System.Collections.Generic;
using System.Text;

namespace MamaApp.Models
{
    public enum MenuItemType
    {
        Browse,
        Meniu,
        Muzică,
        Horoscop,
        Whatsapp,
        Mesaje,
        Telefon,
        Știri,
        Țintar,
        Silențios
      
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
