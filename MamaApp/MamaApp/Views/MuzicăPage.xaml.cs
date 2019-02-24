using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MamaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MuzicăPage : ContentPage
    {
        public MuzicăPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var uri = new Uri("https://www.youtube.com/watch?v=p4QqMKe3rwY");

            Device.OpenUri(uri);
        }
    }
}