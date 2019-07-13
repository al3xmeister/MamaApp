using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MamaApp.Interfaces;
using MamaApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MamaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SoundPage : ContentPage
    {
        private SoundPageViewModel viewModel;
        public SoundPage()
        {
            InitializeComponent();
            viewModel = new SoundPageViewModel();
            BindingContext = viewModel;
        }

        private void SilentMode_Clicked(object sender, EventArgs e)
        {
            var sound = DependencyService.Get<ISoundSettings>();
            sound.SetToSilent();
        }

        private void RingtoneMode_Clicked(object sender, EventArgs e)
        {
            var sound = DependencyService.Get<ISoundSettings>();
            sound.SetRingtoneLevelToLouder();
        }

        private void PhoneVolume_Clicked(object sender, EventArgs e) {

            var sound = DependencyService.Get<ISoundSettings>();
            sound.SetPhoneLevelToLouder();
        }
   
    }
}