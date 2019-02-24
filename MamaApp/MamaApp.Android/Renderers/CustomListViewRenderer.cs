using Android.Content;
using Android.Support.V4.Widget;
using System;
using MamaApp.Controls;
using MamaApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomListView), typeof(TransparentViewCellRenderer))]
namespace MamaApp.Droid.Renderers {
    public class TransparentViewCellRenderer : ListViewRenderer {

        Context _context;

        public TransparentViewCellRenderer(Context context) : base(context) {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e){
            base.OnElementChanged(e);

            try {
                var x = Control.Parent as SwipeRefreshLayout;
                x?.SetColorSchemeColors(global::Android.Graphics.Color.Transparent);
                x?.SetProgressBackgroundColorSchemeColor(Android.Graphics.Color.Transparent);
                x.ScrollBarSize = 0;
                x.ScrollBarFadeDuration = 0;
                x.SetProgressViewOffset(false, -1000, -1000);
                
                
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            if (e.NewElement != null) {
                Control.VerticalScrollBarEnabled = false;
            }
        }
    }
}