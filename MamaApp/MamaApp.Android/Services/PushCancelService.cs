using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Android.Provider;
using Java.Util;
using Android.App;
using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MamaApp.Interfaces;
using MamaApp.Droid.Services;

[assembly: Dependency(typeof(PushCancelService))]
namespace MamaApp.Droid.Services {
    public class PushCancelService : IPushCancel {

        public void CancelPush(int id) {
            var notificationManager = NotificationManagerCompat.From(Android.App.Application.Context);
            notificationManager.CancelAll();

        }
    }
}