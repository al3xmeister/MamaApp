using Android.App;
using Android.Content;
using MamaApp.Droid.Services;
using MamaApp.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(PushCancelService))]
namespace MamaApp.Droid.Services {
    public class PushCancelService : IPushCancel {
        public void ClearNotifications() {

            NotificationManager manager = (NotificationManager)Android.App.Application.Context.GetSystemService(Context.NotificationService);

            manager.CancelAll();
        }
    }
}