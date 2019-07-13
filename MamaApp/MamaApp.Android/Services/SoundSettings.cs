using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MamaApp.Droid.Services;
using MamaApp.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SoundSettings))]
namespace MamaApp.Droid.Services {
    public class SoundSettings : ISoundSettings {

        public void SetToSilent()
        {
            var audioMgr = (AudioManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.AudioService);
            audioMgr.RingerMode = RingerMode.Silent; // In Oreo(+) this will enable DnD mode
        }

        public void SetToVibrate() {
            var audioMgr = (AudioManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.AudioService);
            audioMgr.RingerMode = RingerMode.Vibrate; // In Oreo(+) this will enable DnD mode
        }

        public void SetPhoneLevelToLouder() {
            var audioMgr = (AudioManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.AudioService);
            audioMgr.RingerMode = RingerMode.Normal; // In Oreo(+) this will enable DnD mode
            try {
                audioMgr.AdjustSuggestedStreamVolume(Adjust.Raise, Android.Media.Stream.System, VolumeNotificationFlags.ShowUi);
                audioMgr.AdjustSuggestedStreamVolume(Adjust.Raise, Android.Media.Stream.System, VolumeNotificationFlags.ShowUi);
                audioMgr.AdjustSuggestedStreamVolume(Adjust.Raise, Android.Media.Stream.System, VolumeNotificationFlags.ShowUi);
                audioMgr.AdjustSuggestedStreamVolume(Adjust.Raise, Android.Media.Stream.System, VolumeNotificationFlags.ShowUi);
            } catch (Exception e) {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        public void SetRingtoneLevelToLouder() {
            var audioMgr = (AudioManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.AudioService);
        
            audioMgr.RingerMode = RingerMode.Normal;

            try
            {
                audioMgr.AdjustSuggestedStreamVolume(Adjust.Raise, Android.Media.Stream.Ring, VolumeNotificationFlags.ShowUi);
                audioMgr.AdjustSuggestedStreamVolume(Adjust.Raise, Android.Media.Stream.Ring, VolumeNotificationFlags.ShowUi);
                audioMgr.AdjustSuggestedStreamVolume(Adjust.Raise, Android.Media.Stream.Ring, VolumeNotificationFlags.ShowUi);
                audioMgr.AdjustSuggestedStreamVolume(Adjust.Raise, Android.Media.Stream.Ring, VolumeNotificationFlags.ShowUi);
            }
            catch (Exception e)
            {
               System.Diagnostics.Debug.WriteLine(e);
            }

        }

    }
}