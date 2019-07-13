using System;
using System.Collections.Generic;
using System.Text;
using MamaApp.Interfaces;
using Xamarin.Forms;

namespace MamaApp.ViewModels {
    public class SoundPageViewModel : BaseViewModel
    {

        private string volumeLevel;
        public string VolumeLevel
        {
            get {
                if (volumeLevel != null) {
                    return volumeLevel;
                }
                var sound = DependencyService.Get<ISoundSettings>();
                OnPropertyChanged(nameof(VolumeLevel));
                return sound.GetCurrentRingtoneLevel();
            }
        }

    }
}
