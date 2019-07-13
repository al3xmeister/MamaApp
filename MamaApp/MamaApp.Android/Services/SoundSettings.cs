using System;
using Android.Content;
using Android.Media;
using MamaApp.Droid.Services;
using MamaApp.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SoundSettings))]
namespace MamaApp.Droid.Services {
    public class SoundSettings : ISoundSettings {

        public void SetToSilent()
        {
            var audioMgr = (AudioManager)Android.App.Application.Context.GetSystemService(Context.AudioService);
            audioMgr.RingerMode = RingerMode.Silent; // In Oreo(+) this will enable DnD mode
        }

        public void SetToVibrate() {
            var audioMgr = (AudioManager)Android.App.Application.Context.GetSystemService(Context.AudioService);
            audioMgr.RingerMode = RingerMode.Vibrate; // In Oreo(+) this will enable DnD mode
        }

        public void SetPhoneLevelToLouder() {
            var audioMgr = (AudioManager)Android.App.Application.Context.GetSystemService(Context.AudioService);
            audioMgr.RingerMode = RingerMode.Normal; // In Oreo(+) this will enable DnD mode
            try {

                var maxValue = audioMgr.GetStreamMaxVolume(Stream.Music);
                audioMgr.SetStreamVolume(Stream.System, maxValue, VolumeNotificationFlags.ShowUi);

            } catch (Exception e) {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        public void SetRingtoneLevelToLouder() {
            var audioMgr = (AudioManager)Android.App.Application.Context.GetSystemService(Context.AudioService);
        
            audioMgr.RingerMode = RingerMode.Normal;

            try
            {
                var maxValue = audioMgr.GetStreamMaxVolume(Stream.Ring);
                audioMgr.SetStreamVolume(Stream.Ring, maxValue, VolumeNotificationFlags.ShowUi);
           
            }
            catch (Exception e)
            {
               System.Diagnostics.Debug.WriteLine(e);
            }

        }

        public string GetCurrentRingtoneLevel()
        {
            var audioMgr = (AudioManager)Android.App.Application.Context.GetSystemService(Context.AudioService);
            var volume = audioMgr.GetStreamVolume(Stream.Ring);

            return volume.ToString();
        }
    }
}