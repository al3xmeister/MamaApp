using System;
using System.Diagnostics;
using System.Linq;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;

namespace MamaApp.Views
{
	public partial class NetworkViewPage : ContentPage
	{
		public NetworkViewPage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

           
            if (CrossConnectivity.Current.ConnectionTypes != null)
            {
                ConnectionDetails.Text =
                    CrossConnectivity.Current.ConnectionTypes.FirstOrDefault().ToString() == "Cellular"
                        ? "Fără conexiune la internet"
                        : CrossConnectivity.Current.ConnectionTypes.FirstOrDefault().ToString();

            }

            CrossConnectivity.Current.ConnectivityChanged += UpdateNetworkInfo;
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();

			CrossConnectivity.Current.ConnectivityChanged -= UpdateNetworkInfo;
		}

		private void UpdateNetworkInfo (object sender, ConnectivityChangedEventArgs e)
		{
            try
            {
                if (CrossConnectivity.Current != null && CrossConnectivity.Current.ConnectionTypes != null) {
                    var connectionType = CrossConnectivity.Current.ConnectionTypes.First();
                    ConnectionDetails.Text = connectionType.ToString();
                } else {

                    ConnectionDetails.Text = "Fără conexiune la internet.";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
		
		}
	}
}
